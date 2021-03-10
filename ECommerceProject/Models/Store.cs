using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string URL { get; set; }

        public string Address { get; set; }
        public string LogoURL { get; set; }

        public string BusinessCategory { get; set; }

        [Display(Name = "User")]
        public virtual int User_Id { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}