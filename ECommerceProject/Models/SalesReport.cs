using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class SalesReport
    {
        [Key]
        public int SR_id { get; set; }
        public DateTime Date { get; set; }
        public int Item { get; set; }
        public string Status { get; set; }
        public float Amount { get; set; }
    }
}