using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Bag
    {
        [Key]
        public int BagId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        [Display(Name = "Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product{ get; set; }
    }
}