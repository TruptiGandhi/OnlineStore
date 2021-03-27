namespace ECommerceProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Cats")]
    public partial class Cat
    {
        public int CatId { get; set; }

        [Display(Name="Category Name")]
        public string Name { get; set; }

        [Display(Name ="Image")]
        public string ImageURL { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

 //       public List<Product> products { get; set; }
    }
}
