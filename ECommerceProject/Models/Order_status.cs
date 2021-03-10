using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Order_status
    {
        [Key]
        public int OrderstatusId { get; set; }
        public DateTime Orderstatus_date { get; set; }
        public string Orderstatus_info { get; set; }

        [Display(Name ="Order")]
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}