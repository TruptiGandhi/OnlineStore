using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerceProject.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext():base("Name=MyContext")
        { }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public System.Data.Entity.DbSet<ECommerceProject.Models.Image> Images { get; set; }
    }
}