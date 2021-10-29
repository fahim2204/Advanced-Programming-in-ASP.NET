using LabTask_Product_CRUD_Operation.Models;
using LabTask_Product_CRUD_Operation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask_Product_CRUD_Operation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            Database db = new Database();
            var products = db.Products.Get(id);
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p){
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var products = db.Products.Get(id);
            return View(products);
        }
        [HttpPost]
        //[ActionName("Edit")]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Update(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
       
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.Delete(id);
            return RedirectToAction("Index");
        }

    }
}