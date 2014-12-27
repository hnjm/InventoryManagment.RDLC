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
    public class PriceSetupController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: /PriceSetup/
        public ActionResult Index()
        {
            var pricesetups = db.PriceSetups.Include(p => p.ItemCategory).Include(p => p.ItemInformation);
            return View(pricesetups.ToList());
        }

        // GET: /PriceSetup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceSetup pricesetup = db.PriceSetups.Find(id);
            if (pricesetup == null)
            {
                return HttpNotFound();
            }
            return View(pricesetup);
        }

        // GET: /PriceSetup/Create
        public ViewResult Create(int? cId)
        {
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName");
            var list = db.ItemInformations.Where(p => p.ItemCategoryId == cId);

            ViewBag.ItemInformationId = new SelectList(list, "ItemInformationId", "ItemName");
            return View();
        }
        public PartialViewResult PertialCreate(int? cId)
        {

            var itemList = db.ItemInformations.Where(p => p.ItemCategoryId == cId);
            var priceList = db.PriceSetups.Where(p => p.ItemCategoryId == cId);
            itemList = Enumerable.Aggregate(priceList, itemList, (current, priceSetup) => current.Where(p => p.ItemInformationId != priceSetup.ItemInformationId));
            ViewBag.ItemInformationId = new SelectList(itemList, "ItemInformationId", "ItemName");
            return PartialView("~/Views/Shared/_PartialCreate.cshtml");
        }

        // POST: /PriceSetup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PriceSetupId,ItemCategoryId,ItemInformationId,UnitPrice,Vat")] PriceSetup pricesetup)
        {
            pricesetup.VatPrice = pricesetup.UnitPrice*pricesetup.Vat/100;
            if (ModelState.IsValid)
            {
                db.PriceSetups.Add(pricesetup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName", pricesetup.ItemCategoryId);
            ViewBag.ItemInformationId = new SelectList(db.ItemInformations, "ItemInformationId", "ItemName", pricesetup.ItemInformationId);
            return View(pricesetup);
        }

        // GET: /PriceSetup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceSetup pricesetup = db.PriceSetups.Find(id);
            if (pricesetup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName", pricesetup.ItemCategoryId);
            ViewBag.ItemInformationId = new SelectList(db.ItemInformations, "ItemInformationId", "ItemName", pricesetup.ItemInformationId);
            return View(pricesetup);
        }

        // POST: /PriceSetup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PriceSetupId,ItemCategoryId,ItemInformationId,UnitPrice,Vat")] PriceSetup pricesetup)
        {
            pricesetup.VatPrice = pricesetup.UnitPrice * pricesetup.Vat / 100;
            if (ModelState.IsValid)
            {
                db.Entry(pricesetup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategories, "ItemCategoryId", "ItemCategoryName", pricesetup.ItemCategoryId);
            ViewBag.ItemInformationId = new SelectList(db.ItemInformations, "ItemInformationId", "ItemName", pricesetup.ItemInformationId);
            return View(pricesetup);
        }

        // GET: /PriceSetup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceSetup pricesetup = db.PriceSetups.Find(id);
            if (pricesetup == null)
            {
                return HttpNotFound();
            }
            return View(pricesetup);
        }

        // POST: /PriceSetup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceSetup pricesetup = db.PriceSetups.Find(id);
            db.PriceSetups.Remove(pricesetup);
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
    }
}
