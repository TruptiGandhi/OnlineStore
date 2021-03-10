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

    }
}
