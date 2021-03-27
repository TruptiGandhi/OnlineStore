using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_id { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public Boolean IsCategoryAvailable { get; set; }

        public string VisibilityType { get; set; }
        
        [Display(Name ="CategoryId")]
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "ImageId")]
        public virtual int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}