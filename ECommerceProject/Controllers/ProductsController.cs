using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ECommerceProject.Models;
using PagedList;

namespace ECommerceProject.Controllers
{
    
    public class ProductsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Products
        /*public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Cat);
            return View(products.ToList());
        }*/
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            //var store = from s in db.Stores select s;
            //store = store.Where(s);
            var pro = from p in db.Products select p;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                pro = pro.Where(c => c.ProductName.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    pro = pro.OrderByDescending(c => c.ProductName);
                    break;
                default:
                    pro = pro.OrderBy(c => c.ProductName);
                    break;
            }
            int Size_Of_Page = 5;
            int No_Of_Page = (Page_No ?? 1);
            return View(pro.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CatId = new SelectList(db.Cats, "CatId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImageURL = "../ProductImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("../ProductImages/"), fileName);
                product.ImageFile.SaveAs(fileName);
                db.Products.Add(product);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            ViewBag.CatId = new SelectList(db.Cats, "CatId", "Name", product.CatId);
            return View(product);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatId = new SelectList(db.Cats, "CatId", "Name", product.CatId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImageURL = "~/producteditedimages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/producteditedimages/"), fileName);
                product.ImageFile.SaveAs(fileName);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            ViewBag.CatId = new SelectList(db.Cats, "CatId", "Name", product.CatId);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
