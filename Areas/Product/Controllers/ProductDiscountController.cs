using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementsystem.Areas.Product.Controllers
{
    public class ProductDiscountController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();
        // GET: Product/ProductDiscount
        public ActionResult Index()
        {
            return View(db.ProductDiscounts.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDiscount pd)
        {
            db.ProductDiscounts.Add(pd);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                ProductDiscount pd = db.ProductDiscounts.Find(id);             
                return View(pd);
            }
            return HttpNotFound();  
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                ProductDiscount pd = db.ProductDiscounts.Find(id);
                return View(pd);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ProductDiscount pd)
        {
            ProductDiscount existingrecord = db.ProductDiscounts.Find(pd.DiscountID);
            existingrecord.DiscountName = pd.DiscountName;
            existingrecord.Description = pd.Description;
            existingrecord.IsActive = pd.IsActive;
            existingrecord.DiscountPercent = pd.DiscountPercent;
            existingrecord.StartDate = pd.StartDate;
            existingrecord.EndDate = pd.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                ProductDiscount pd = db.ProductDiscounts.Find(id);
                return View(pd);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(ProductDiscount pd)
        {
            int? id = pd.DiscountID;
            if (id != null)
            {
                ProductDiscount foundProduct = db.ProductDiscounts.Find(id);
                db.ProductDiscounts.Remove(foundProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }

 
}