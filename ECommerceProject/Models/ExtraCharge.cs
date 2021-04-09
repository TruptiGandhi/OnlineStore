using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class ExtraCharge
    {
        [Key]
        public int EC_id { get; set; }

        [Required]
        [Display(Name = "Delivery charge per order")]
        public int del_charge { get; set; }

        [Required]
        [Display(Name = "Free delivery above")]
        public int? free_delivery { get; set; }

        [Display(Name ="GST Number")]
        public int? GSTNumber {get;set;}

        [Display(Name ="GST Percentage")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Range(1,100,ErrorMessage ="Percentage can't be greater than 100")]
        public double GSTPercentage { get; set; }

        [Display(Name ="Charge Name")]
        public string Chargename { get; set; }

        [Display(Name ="Charges in rupees")]
        public int? chargeinrupees { get; set; }
    }
}