using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        [Required]
        public string BusinessCategory { get; set; }
    }
}