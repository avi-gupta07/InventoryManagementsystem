//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagementsystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public int CategoryID { get; set; }
        public int InventoryID { get; set; }
        public decimal Price { get; set; }
        public int DiscountID { get; set; }
    
        public virtual Product_Category Product_Category { get; set; }
        public virtual ProductDiscount ProductDiscount { get; set; }
        public virtual Product_Inventory Product_Inventory { get; set; }
    }
}
