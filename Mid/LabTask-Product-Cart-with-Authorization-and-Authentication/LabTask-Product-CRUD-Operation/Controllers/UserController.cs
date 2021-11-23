using LabTask_Product_CRUD_Operation.Auth;
using LabTask_Product_CRUD_Operation.Models;
using LabTask_Product_CRUD_Operation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LabTask_Product_CRUD_Operation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            Database db = new Database();
            var users = db.Users.Get();
            return View(users);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                var flag = db.Users.Authenticate(p);
                if (flag!=null)
                {
                    FormsAuthentication.SetAuthCookie(flag.ToString(),true);
                    return RedirectToAction("Index");
                }
                
            }
            return View(p);
        }
        [AdminAccess]
        public ActionResult Create()
        {
            User p = new User();
            return View(p);
        }
        [HttpPost]
        [AdminAccess]
        public ActionResult Create(User p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Users.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}