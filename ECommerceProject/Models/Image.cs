using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageURL { get; set; }

        public int ImageitemId { get; set; }

        public string Imagetype { get; set; }
    }
}