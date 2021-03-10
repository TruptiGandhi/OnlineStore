using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        public int MRP { get; set; }

        public int SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductVariant { get; set; }
        public bool IsProductAvailable { get; set; }
        public string VisibilityType { get; set; }

        [Display(Name = "CategoryId")]
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "SubCategory")]
        public virtual int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}