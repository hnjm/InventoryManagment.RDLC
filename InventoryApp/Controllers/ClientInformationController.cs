using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Models;
using InventoryApp.Reports;

namespace InventoryApp.Controllers
{
    public class ClientInformationController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: /ClientInformation/

      

        public ActionResult Index()
        {
            return View(db.ClientInformations.ToList());
        }

        // GET: /ClientInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientinformation = db.ClientInformations.Find(id);
            if (clientinformation == null)
            {
                return HttpNotFound();
            }
            return View(clientinformation);
        }

        // GET: /ClientInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ClientInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ClientInformationId,ClientCode,ClientName,ContactPerson,Address,Email,MobileNumber")] ClientInformation clientinformation)
        {
            clientinformation.CreatedDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ClientInformations.Add(clientinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientinformation);
        }

        // GET: /ClientInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientinformation = db.ClientInformations.Find(id);
            if (clientinformation == null)
            {
                return HttpNotFound();
            }
            return View(clientinformation);
        }

        // POST: /ClientInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ClientInformationId,ClientCode,ClientName,ContactPerson,Address,Email,MobileNumber")] ClientInformation clientinformation)
        {
            clientinformation.CreatedDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(clientinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientinformation);
        }

        // GET: /ClientInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInformation clientinformation = db.ClientInformations.Find(id);
            if (clientinformation == null)
            {
                return HttpNotFound();
            }
            return View(clientinformation);
        }

        // POST: /ClientInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientInformation clientinformation = db.ClientInformations.Find(id);
            db.ClientInformations.Remove(clientinformation);
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



        public JsonResult ClientCodeExist(ClientInformation aClientInformation)
        {
            return
                Json(!db.ClientInformations.Where(c => c.ClientInformationId != aClientInformation.ClientInformationId)
                    .Any(c => c.ClientCode == aClientInformation.ClientCode),
                    JsonRequestBehavior.AllowGet);

        }

        public JsonResult ClientNameExist(ClientInformation aClientInformation)
        {
            return
                Json(!db.ClientInformations.Where(c => c.ClientInformationId != aClientInformation.ClientInformationId)
                    .Any(c => c.ClientName == aClientInformation.ClientName),
                    JsonRequestBehavior.AllowGet);
        }


        public JsonResult EmailExist(ClientInformation aClientInformation)
        {
            return
                Json(!db.ClientInformations.Where(c => c.ClientInformationId != aClientInformation.ClientInformationId)
                    .Any(c => c.Email == aClientInformation.Email),
                    JsonRequestBehavior.AllowGet);

        }

        public JsonResult MobileNumberExist(ClientInformation aClientInformation)
        {
            return
                Json(!db.ClientInformations.Where(c => c.ClientInformationId != aClientInformation.ClientInformationId)
                    .Any(c => c.MobileNumber == aClientInformation.MobileNumber),
                    JsonRequestBehavior.AllowGet);
        }
    }
}
