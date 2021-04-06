using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ECommerceProject.Models;
using System.Configuration;
using PagedList;

namespace ECommerceProject.Controllers
{
    
    public class CatsController : Controller
    {
        public string currentCategoryName;
        private MyDBContext db = new MyDBContext();

        // GET: Cats
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
            var category = from c in db.Cats select c;
            if (!String.IsNullOrEmpty(Search_Data))
            {
                category = category.Where(c => c.Name.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    category = category.OrderByDescending(c => c.Name);
                    break;
                default:
                    category = category.OrderBy(c => c.Name);
                    break;
            }
            int Size_Of_Page = 3;
            int No_Of_Page = (Page_No ?? 1);
            return View(category.ToPagedList(No_Of_Page, Size_Of_Page));
            //return View(db.Cats.ToList());
        }

        public ActionResult ShowIndex()
        {
            var categories = db.Cats.ToList();
            return View(categories);
        }

        // GET: Cats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = db.Cats.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat cat)
        {
            string fileName = Path.GetFileNameWithoutExtension(cat.ImageFile.FileName);
            string extension = Path.GetExtension(cat.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            cat.ImageURL = "../UploadedFiles/" + fileName;
            fileName = Path.Combine(Server.MapPath("../UploadedFiles/"), fileName);
            cat.ImageFile.SaveAs(fileName);
            using(DBmodel dBmodel = new DBmodel())
            {
                dBmodel.Cats.Add(cat);
                dBmodel.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = db.Cats.Find(id);
            Session["imgPath"] = cat.ImageURL;
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cat cat)
        {
                string fileName = Path.GetFileNameWithoutExtension(cat.ImageFile.FileName);
                string extension = Path.GetExtension(cat.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cat.ImageURL = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                cat.ImageFile.SaveAs(fileName);
                using (DBmodel dBmodel = new DBmodel())
                {
                    dBmodel.Entry(cat).State = EntityState.Modified;
                    dBmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
        }

            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cat cat = db.Cats.Find(id);
                if (cat == null)
                {
                    return HttpNotFound();
                }
                return View(cat);
            }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat cat = db.Cats.Find(id);
            db.Cats.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Browse(string category)
        {
            var categoryModel = db.Cats.FirstOrDefault(c => c.Name == category);
            ViewBag.Name = category;
            currentCategoryName = category;
            ViewBag.id = categoryModel.CatId;
            var items = db.Products.ToList();
            return View(items);
        }

        public ActionResult ProductDetails(int id)
        {
            var item = db.Products.Include(i => i.Cat).First(i => i.ProductId == id);
            return View(item);
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
