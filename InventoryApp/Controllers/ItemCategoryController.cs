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
    public class ItemCategoryController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: /ItemCategory/
        public ActionResult Index()
        {
            return View(db.ItemCategories.ToList());
        }

        // GET: /ItemCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemcategory = db.ItemCategories.Find(id);
            if (itemcategory == null)
            {
                return HttpNotFound();
            }
            return View(itemcategory);
        }

        // GET: /ItemCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ItemCategoryId,ItemCategoryCode,ItemCategoryName,Remarks")] ItemCategory itemcategory)
        {
            if (ModelState.IsValid)
            {
                db.ItemCategories.Add(itemcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemcategory);
        }

        // GET: /ItemCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemcategory = db.ItemCategories.Find(id);
            if (itemcategory == null)
            {
                return HttpNotFound();
            }
            return View(itemcategory);
        }

        // POST: /ItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ItemCategoryId,ItemCategoryCode,ItemCategoryName,Remarks")] ItemCategory itemcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemcategory);
        }

        // GET: /ItemCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemcategory = db.ItemCategories.Find(id);
            if (itemcategory == null)
            {
                return HttpNotFound();
            }
            return View(itemcategory);
        }

        // POST: /ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCategory itemcategory = db.ItemCategories.Find(id);
            db.ItemCategories.Remove(itemcategory);
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
        public JsonResult CodeExist(ItemCategory aItemCategory)
        {
            return
                Json(!db.ItemCategories.Where(c => c.ItemCategoryId != aItemCategory.ItemCategoryId)
                    .Any(c => c.ItemCategoryCode == aItemCategory.ItemCategoryCode),
                    JsonRequestBehavior.AllowGet);

        }
    }
}
