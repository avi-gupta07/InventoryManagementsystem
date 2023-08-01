using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementsystem.Areas.Product.Controllers
{

    public class ProductInventoryController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();
        // GET: Product/ProductInventory
        public ActionResult Index()
        {
            return View(db.Product_Inventory.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product_Inventory pi)
        {
            db.Product_Inventory.Add(pi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Product_Inventory pi = db.Product_Inventory.Find(id);
                return View(pi);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Product_Inventory pi)
        {
            var ExistingRecord = db.Product_Inventory.Find(pi.ProductInventoryID);
            ExistingRecord.Name = pi.Name;
            ExistingRecord.Quantity = pi.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product_Inventory pi = db.Product_Inventory.Find(id);
                return View(pi);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(Product_Inventory pi)
        {
            int? id = pi.ProductInventoryID;
            if (id != null)
            {
                Product_Inventory foundProduct = db.Product_Inventory.Find(id);
                db.Product_Inventory.Remove(foundProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Product_Inventory pi = db.Product_Inventory.Find(id);
                return View(pi);
            }
            return HttpNotFound();
        }
    }
}