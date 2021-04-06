using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Display(Name ="Coupon Code")]
        [MinLength(5,ErrorMessage ="Minimum Length is 5 characters")]
        public string CouponCode { get; set; }

        [Display(Name ="Uses per customer")]
        
        public int UsesPerCustomer { get; set; }
        public int Discount_amount { get; set; }
        public int Min_OrderValue { get; set; }

        [Display(Name = "Store")]
        public virtual int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}