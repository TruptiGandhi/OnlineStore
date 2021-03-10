using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Address
    {
        [Key]
        public int Address_id { get; set; }

        [Required]
        public string CustomerAddress { get; set; }
    }
}