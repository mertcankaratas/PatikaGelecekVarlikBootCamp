using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class GrootContext:DbContext
    {

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=desktop-9d6tod0\sqlexpress;Database=Groot;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-C3QIC5D;Database=Groot;Trusted_Connection=true");
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
