using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject.Models;

namespace ECommerceProject.Controllers
{
    public class ExtraChargesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: ExtraCharges
        public ActionResult Index()
        {
            return View(db.extraCharges.ToList());
        }

        // GET: ExtraCharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCharge extraCharge = db.extraCharges.Find(id);
            if (extraCharge == null)
            {
                return HttpNotFound();
            }
            return View(extraCharge);
        }

        // GET: ExtraCharges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraCharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EC_id,del_charge,free_delivery,GSTNumber,GSTPercentage,Chargename,chargeinrupees")] ExtraCharge extraCharge)
        {
            if (ModelState.IsValid)
            {
                db.extraCharges.Add(extraCharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraCharge);
        }

        // GET: ExtraCharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCharge extraCharge = db.extraCharges.Find(id);
            if (extraCharge == null)
            {
                return HttpNotFound();
            }
            return View(extraCharge);
        }

        // POST: ExtraCharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EC_id,del_charge,free_delivery,GSTNumber,GSTPercentage,Chargename,chargeinrupees")] ExtraCharge extraCharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraCharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraCharge);
        }

        // GET: ExtraCharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCharge extraCharge = db.extraCharges.Find(id);
            if (extraCharge == null)
            {
                return HttpNotFound();
            }
            return View(extraCharge);
        }

        // POST: ExtraCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraCharge extraCharge = db.extraCharges.Find(id);
            db.extraCharges.Remove(extraCharge);
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
