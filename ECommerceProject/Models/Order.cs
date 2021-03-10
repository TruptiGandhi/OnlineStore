using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float DeliveryCharge { get; set; }
        public string GSTNumber { get; set; }
        public float GSTPercentage { get; set; }
        public string ExtraChargeName { get; set; }
        public float ExtraChargePercentage { get; set; }
        [Display(Name = "Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Display(Name = "Coupon")]
        public virtual int CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}