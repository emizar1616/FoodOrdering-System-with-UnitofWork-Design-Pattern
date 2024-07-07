using Istka_Group4_FoodOrdering_DataAccess.Identity;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_DataAccess.Contexts
{
    public class FoodDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSale> ProductSales { get; set; }
        public virtual DbSet<ProductSaleDetail> ProductSaleDetails { get; set; }
    }
}
