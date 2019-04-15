using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcApplication4.Models
{
    public class WebShopContext : DbContext
    {
        //public DbSet<Book> Books { get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
  
}