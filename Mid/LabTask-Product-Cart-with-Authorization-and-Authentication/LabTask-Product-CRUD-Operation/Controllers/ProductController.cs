using LabTask_Product_CRUD_Operation.Auth;
using LabTask_Product_CRUD_Operation.Models;
using LabTask_Product_CRUD_Operation.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        [Authorize]
        public ActionResult Details(int id)
        {
            Database db = new Database();
            var products = db.Products.Get(id);
            return View(products);
        }
        [HttpGet]
        [AdminAccess]
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
        [AdminAccess]
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
        [AdminAccess]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int id)
        {
            Database db = new Database();
            var product = db.Products.Get(id);

            if (Session["cart"] == null)
            {
                List<Product> tempcart = new List<Product>();
                tempcart.Add(product);
                Session["cart"] = JsonConvert.SerializeObject(tempcart);
                //Console.WriteLine(Session["cart"]);
                //System.Diagnostics.Debug.WriteLine("SomeText");

            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                d.Add(product);
                Session["cart"] = JsonConvert.SerializeObject(d);
                System.Diagnostics.Debug.WriteLine(Session["cart"]);
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Cart()
        {
            if (Session["cart"] == null)
            {
                return View(new List<Product>());
            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                return View(d);
            }
           
        }

    }
}