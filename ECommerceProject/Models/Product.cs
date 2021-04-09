using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name ="Product Description")]
        public string Description { get; set; }

        [Required]
        public int MRP { get; set; }

        [Display(Name ="Selling Price")]
        public int SellingPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
        public bool IsProductAvailable { get; set; }
        public string VisibilityType { get; set; }
        [Display(Name ="Product Image")]
        public string ImageURL { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        //public List<HttpPostedFileBase> files { get; set; }

        [Display(Name = "Choose Category")]
        public virtual int CatId { get; set; }
        [Display(Name = "Choose Category")]
        public virtual Cat Cat { get; set; }

      
    }
}