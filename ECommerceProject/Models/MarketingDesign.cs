using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class MarketingDesign
    {
        [Key]
        public int MD_id { get; set; }
        public Image BusinessCard { get; set; }
        public Image PromoBanner { get; set; }

        [Display(Name = "Store")]
        public virtual int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}