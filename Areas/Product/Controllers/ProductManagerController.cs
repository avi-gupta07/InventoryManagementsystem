using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace InventoryManagementsystem.Areas.Product.Controllers
{
    public class ProductManagerController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();
        // GET: Product/Product
        public ActionResult Index()
        {
           var products = db.Products
                            .Include(pc => pc.Product_Category)
                            .Include(pi => pi.Product_Inventory)
                            .Include(pd => pd.ProductDiscount)
                            .ToList();
            return View(products);
        }

        public ActionResult Create()
        {
             
            List<Product_Category> ListPC = db.Product_Category.ToList();            
            ViewBag.ListProductCategory = ListPC;

            List<Product_Inventory> ListPI = db.Product_Inventory.ToList();      
            ViewBag.ListProductInventory = ListPI;

            List<ProductDiscount> ListDis = db.ProductDiscounts.ToList();       
            ViewBag.ListProductDiscount = ListDis;

            return View();
        }

        [HttpPost]
        public ActionResult Create(InventoryManagementsystem.Product product)
        {
            db.Products.Add(product);  
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var product = db.Products
                            .Include(pc => pc.Product_Category)
                            .Include(pi => pi.Product_Inventory)
                            .Include(pd => pd.ProductDiscount)
                            .FirstOrDefault(pr=> pr.ProductID ==id);
                return View(product);
            }
            return HttpNotFound();
        }
       
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var product = db.Products.Find(id);
                List<Product_Category> ListPC = db.Product_Category.ToList();
                ViewBag.ListProductCategory = ListPC;

                List<Product_Inventory> ListPI = db.Product_Inventory.ToList();
                ViewBag.ListProductInventory = ListPI;

                List<ProductDiscount> ListDis = db.ProductDiscounts.ToList();
                ViewBag.ListProductDiscount = ListDis;
                return View(product);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(InventoryManagementsystem.Product product)
        {
            if (product != null)
            {
                var ExistingRecord = db.Products.Find(product.ProductID);
                ExistingRecord.Name = product.Name;
                ExistingRecord.Description = product.Description;
                ExistingRecord.SKU = product.SKU;
                ExistingRecord.CategoryID = product.CategoryID;
                ExistingRecord.InventoryID = product.InventoryID;
                ExistingRecord.Price = product.Price;
                ExistingRecord.DiscountID = product.DiscountID;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }


        public ActionResult Delete(int? id) {
            if (id != null)
            {
                var product = db.Products
                          .Include(pc => pc.Product_Category)
                          .Include(pi => pi.Product_Inventory)
                          .Include(pd => pd.ProductDiscount)
                          .FirstOrDefault(pr => pr.ProductID == id);


                return View(product);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(InventoryManagementsystem.Product product)
        {
            int? id = product.ProductID;
            if (product != null)
            {
                var foundProduct = db.Products.Find(id);
                if (foundProduct != null)
                {
                    db.Products.Remove(foundProduct);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}