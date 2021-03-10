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
    }
}