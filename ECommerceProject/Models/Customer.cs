using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ECommerceProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int Pincode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ContactNo { get; set; }
        public int Address_id { get; set; }
        public virtual Address Address { get; set; }
    }
}