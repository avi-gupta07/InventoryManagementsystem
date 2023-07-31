using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementsystem.Areas.Product.Controllers
{
    public class ProductCategoryController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();
        // GET: Product/ProductCategory
        public ActionResult Index()
        {
            return View(db.Product_Category.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product_Category pc)
        {
            db.Product_Category.Add(pc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Product_Category pc = db.Product_Category.Find(id);
                return View(pc);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Product_Category pc)
        {
            var ExistingRecord = db.Product_Category.Find(pc.ProductCategoryID);

            ExistingRecord.Name = pc.Name;
            ExistingRecord.Description = pc.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
            
                
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product_Category pc = db.Product_Category.Find(id);
                return View(pc);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(Product_Category pc)
        {
            int? id = pc.ProductCategoryID;
            if (id != null) {
                Product_Category foundProduct = db.Product_Category.Find(id);
                db.Product_Category.Remove(foundProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Product_Category pc = db.Product_Category.Find(id);
                return View(pc);
            }

            return HttpNotFound();
        }

    }
}