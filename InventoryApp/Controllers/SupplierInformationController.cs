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
    public class SupplierInformationController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: /SupplierInformation/
        public ActionResult Index()
        {
            return View(db.SupplierInformations.ToList());
        }

        // GET: /SupplierInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierInformation supplierinformation = db.SupplierInformations.Find(id);
            if (supplierinformation == null)
            {
                return HttpNotFound();
            }
            return View(supplierinformation);
        }

        // GET: /SupplierInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SupplierInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SupplierInformationId,SupplierCode,SupplierName,ContactPerson,Address,Email,MobileNumber")] SupplierInformation supplierinformation)
        {
            supplierinformation.CreatedDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.SupplierInformations.Add(supplierinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierinformation);
        }

        // GET: /SupplierInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierInformation supplierinformation = db.SupplierInformations.Find(id);
            if (supplierinformation == null)
            {
                return HttpNotFound();
            }
            return View(supplierinformation);
        }

        // POST: /SupplierInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SupplierInformationId,SupplierCode,SupplierName,ContactPerson,Address,Email,MobileNumber")] SupplierInformation supplierinformation)
        {
            supplierinformation.CreatedDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(supplierinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierinformation);
        }

        // GET: /SupplierInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierInformation supplierinformation = db.SupplierInformations.Find(id);
            if (supplierinformation == null)
            {
                return HttpNotFound();
            }
            return View(supplierinformation);
        }

        // POST: /SupplierInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierInformation supplierinformation = db.SupplierInformations.Find(id);
            db.SupplierInformations.Remove(supplierinformation);
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
        public JsonResult CodeExist(SupplierInformation aSupplierInformation)
        {
            return Json(!db.SupplierInformations.Where(c => c.SupplierInformationId != aSupplierInformation.SupplierInformationId)
                .Any(c => c.SupplierCode == aSupplierInformation.SupplierCode),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult NameExist(SupplierInformation aSupplierInformation)
        {
            return Json(!db.SupplierInformations.Where(c => c.SupplierInformationId != aSupplierInformation.SupplierInformationId)
                .Any(c => c.SupplierName == aSupplierInformation.SupplierName),
                JsonRequestBehavior.AllowGet);
        }


        public JsonResult EmailExist(SupplierInformation aSupplierInformation)
        {
            return Json(!db.SupplierInformations.Where(c => c.SupplierInformationId != aSupplierInformation.SupplierInformationId)
                .Any(c => c.Email == aSupplierInformation.Email),
                JsonRequestBehavior.AllowGet);

        }
        public JsonResult MobileNumberExist(SupplierInformation aSupplierInformation)
        {
            return Json(!db.SupplierInformations.Where(c => c.SupplierInformationId != aSupplierInformation.SupplierInformationId)
                .Any(c => c.MobileNumber == aSupplierInformation.MobileNumber),
                JsonRequestBehavior.AllowGet);
        }
    }
}
