using ECommerceProject.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject.Controllers
{

    public class AccountController : Controller
    {
        
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDetails userDetails)
        {
            if(userDetails.FirstName == userDetails.LastName)
            {
                ModelState.AddModelError("LastName",
                                 "The last name cannot be the same as the first name.");
            }
            if (ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    db.UserDetails.Add(userDetails);
                    db.SaveChanges();
                    ViewBag.Message = "Registered Successfully";
                    return this.RedirectToAction("Create", "Stores");
                }
            }

            return View(userDetails);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            if (ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    var data = db.UserDetails.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                    if (data.Count() > 0)
                    {
                        Session["FirstName"] = data.FirstOrDefault().FirstName;
                        Session["LastName"] = data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["User_id"] = data.FirstOrDefault().User_id;
                        if(email == "admin@gmail.com" && password == "Admin@123")
                        {
                            Session["Role"] = "Admin";
                            return RedirectToAction("AdminLoggedIn");
                        }
                        return this.RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or Password does not match.");
                        //ViewBag.error = "Email or Password does not match";
                        //return RedirectToAction("Login");
                    }
                }
            }
                return View();
        }
      
        
        public ActionResult AdminLoggedIn()
        {
            if (Session["User_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}