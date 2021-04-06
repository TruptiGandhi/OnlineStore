using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Display(Name ="Store Name")]
        [Required]
        public string StoreName { get; set; }

        [Required]
        public string URL { get; set; }

        [Display(Name ="Store Address")]
        public string Address { get; set; }

        [Display(Name ="Store Logo")]
        public string LogoURL { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string BusinessCategory { get; set; }

        [Display(Name = "User")]
        public virtual int User_Id { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}