using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject.Models;
using System.IO;

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
        public ActionResult Create(Store store)
        {  
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(store.ImageFile.FileName);
                string extension = Path.GetExtension(store.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                store.LogoURL = "../StoreImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("../StoreImages/"), fileName);
                store.ImageFile.SaveAs(fileName);
                    db.Stores.Add(store);
                    db.SaveChanges();
                ModelState.Clear();
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
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(store.ImageFile.FileName);
                string extension = Path.GetExtension(store.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                store.LogoURL = "~/StoreEditedImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/StoreEditedImages/"), fileName);
                store.ImageFile.SaveAs(fileName);
                    db.Entry(store).State = EntityState.Modified;
                    db.SaveChanges();
                ModelState.Clear();
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

        /*public ActionResult NewProduct(Store store)
        {
            ProductsController pc = new ProductsController();
            return View();
        }*/

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
