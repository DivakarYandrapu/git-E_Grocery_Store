using E_Grocery_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.DBContext
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Register> Register { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroceryCategory> GroceryCategory { get; set; }
        public DbSet<GroceryItems> GroceryItems { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

    }
}
