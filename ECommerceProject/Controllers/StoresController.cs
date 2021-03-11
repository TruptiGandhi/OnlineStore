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
    public class StoresController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.UserDetails);
            return View(stores.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.UserDetails, "User_id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreId,StoreName,URL,Address,LogoURL,BusinessCategory,User_Id")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.UserDetails, "User_id", "FirstName", store.User_Id);
            return View(store);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.UserDetails, "User_id", "FirstName", store.User_Id);
            return View(store);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreId,StoreName,URL,Address,LogoURL,BusinessCategory,User_Id")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.UserDetails, "User_id", "FirstName", store.User_Id);
            return View(store);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
