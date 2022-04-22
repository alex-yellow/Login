using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        UserContext db = new UserContext();
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Name + " " + "успешно зарегестрирован";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = db.Users.Single(u => u.Name == user.Name && u.Password == user.Password);
            if(usr==null)
            {
                return RedirectToAction("Index");
            }
            Session["Id"] = usr.Id.ToString();
            Session["Name"] = usr.Name.ToString();
            return RedirectToAction("LoggedIn");
        }
        public ActionResult LoggedIn()
        {
            if(Session["Id"]!=null)
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