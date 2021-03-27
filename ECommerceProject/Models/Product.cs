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
        [Required]
        public int Quantity { get; set; }
        public string ProductVariant { get; set; }
        public bool IsProductAvailable { get; set; }
        public string VisibilityType { get; set; }
        [Display(Name ="Image")]
        public string ImageURL { get; set; }
        //public List<HttpPostedFileBase> files { get; set; }

        [Display(Name = "CatId")]
        public virtual int CatId { get; set; }
        public virtual Cat Cat { get; set; }
    }
}