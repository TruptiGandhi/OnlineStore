using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public float Amount { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }

        [Display(Name = "Customer")]
        public virtual int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Order")]
        public virtual int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}