using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registration(tbl_UserRegistration user)
        {
            WebAppEntities db = new WebAppEntities();
            db.tbl_UserRegistration.Add(user);
            db.SaveChanges();
            return View();
        }

        public ActionResult ListView()
        {
            WebAppEntities db = new WebAppEntities();
            var user = db.tbl_UserRegistration.ToList();
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_UserRegistration objUser)
        {
            WebAppEntities db = new WebAppEntities();
            var user = db.tbl_UserRegistration.Where(x => x.UserName == objUser.UserName && x.Password == objUser.Password).Count();

            if(user > 0)
            {
                return RedirectToAction("ListView");
            }
            else
            {
                return View();
            }
                
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppEntities db = new WebAppEntities();
            var userId = db.tbl_UserRegistration.Find(id);
            return View(userId);
        }

        [HttpPost]
        public ActionResult Edit(tbl_UserRegistration EditReg)
        {
            WebAppEntities db = new WebAppEntities();
            db.Entry(EditReg).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit");
          
        }


    }
}