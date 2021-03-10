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
        public string CouponCode { get; set; }
        public int UsesPerCustomer { get; set; }
        public int Discount_amount { get; set; }
        public int Min_OrderValue { get; set; }

        [Display(Name = "Store")]
        public virtual int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}