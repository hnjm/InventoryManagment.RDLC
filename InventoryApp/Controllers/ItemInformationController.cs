using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class ItemInformationController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: /ItemInformation/
        public ActionResult Index()
        {
            var iteminformations = db.ItemInformations.Include(i => i.ItemCategory).Include(i => i.ItemType).Include(i => i.Uom);
            return View(iteminformations.ToList());
        }

        // GET: /ItemInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInformation iteminformation = db.ItemInformations.Find(id);
            if (iteminformation == null)
            {
                return HttpNotFound();
            }
            return View(iteminformation);
        }

        // GET: /ItemInformation/Create
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName");
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName");
            ViewBag.UomId = new SelectList(db.Uoms, "UomId", "UomName");
            return View();
        }

        // POST: /ItemInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ItemInformationId,ItemCode,ItemName,ItemCategoryId,ItemTypeId,UomId,Remarks")] ItemInformation iteminformation)
        {
            if (ModelState.IsValid)
            {
                db.ItemInformations.Add(iteminformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName", iteminformation.ItemCategoryId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName", iteminformation.ItemTypeId);
            ViewBag.UomId = new SelectList(db.Uoms, "UomId", "UomName", iteminformation.UomId);
            return View(iteminformation);
        }

        // GET: /ItemInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInformation iteminformation = db.ItemInformations.Find(id);
            if (iteminformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryCode", iteminformation.ItemCategoryId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName", iteminformation.ItemTypeId);
            ViewBag.UomId = new SelectList(db.Uoms, "UomId", "UomName", iteminformation.UomId);
            return View(iteminformation);
        }

        // POST: /ItemInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ItemInformationId,ItemCode,ItemName,ItemCategoryId,ItemTypeId,UomId,Remarks")] ItemInformation iteminformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iteminformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryCode", iteminformation.ItemCategoryId);
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "ItemTypeId", "ItemName", iteminformation.ItemTypeId);
            ViewBag.UomId = new SelectList(db.Uoms, "UomId", "UomName", iteminformation.UomId);
            return View(iteminformation);
        }

        // GET: /ItemInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInformation iteminformation = db.ItemInformations.Find(id);
            if (iteminformation == null)
            {
                return HttpNotFound();
            }
            return View(iteminformation);
        }

        // POST: /ItemInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemInformation iteminformation = db.ItemInformations.Find(id);
            db.ItemInformations.Remove(iteminformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult CodeExist(ItemInformation aItemInformation)
        {
            return
                Json(!db.ItemInformations.Where(c => c.ItemInformationId != aItemInformation.ItemInformationId)
                    .Any(c => c.ItemCode == aItemInformation.ItemCode),
                    JsonRequestBehavior.AllowGet);

        }
    }
}
