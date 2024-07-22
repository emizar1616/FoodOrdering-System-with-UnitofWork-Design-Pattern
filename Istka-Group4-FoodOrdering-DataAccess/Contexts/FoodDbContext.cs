using Istka_Group4_FoodOrdering_DataAccess.Identity;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_DataAccess.Contexts
{
    public class FoodDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }      
        public virtual DbSet<Category> Categories { get; set; }
       
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSale> ProductSales { get; set; }
        public virtual DbSet<ProductSaleDetail> ProductSaleDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API  Validation
            builder.Entity<Category>().Property("Name").IsRequired().HasMaxLength(100);
            builder.Entity<Product>().Property("Name").IsRequired().HasMaxLength(100);
            builder.Entity<Product>().Property(p =>p.isDiscount).HasDefaultValue(true);
            builder.Entity<Feedback>().Property("Description").IsRequired();

            //Seed Data

            builder.Entity<Category>().HasData(
                    new Category() { Id = 1, Name = "Salatalar"},
                    new Category() { Id = 2, Name = "Pizzalar" },
                    new Category() { Id = 3, Name = "Burgerler" },
                    new Category() { Id = 4 ,Name="Tatlılar"},
                    new Category() { Id = 5, Name = "İçecekler" },
                    new Category() { Id = 6, Name = "Deniz Ürünleri" }
                );

            builder.Entity<Product>().HasData(
                  new Product() { Id=1, Name="Chicken Burger",Description="Tavuk burger köftesi,göbek marul,mayonez",LastConsumption=Convert.ToDateTime("01.08.2024"),Stock=15,Price=85,ImageUrl="/images/chickenburger.jpg",isDiscount=false,CategoryId=3},
                 new Product() { Id =2, Name = "Cheese Burger", Description = "Dana köfte,özel sos,cheddar peyniri", LastConsumption = Convert.ToDateTime("04.08.2024"), Stock = 25, Price =145, ImageUrl = "/images/cheeseburger.jpg", isDiscount = false, CategoryId = 3 },
                 new Product() { Id = 3, Name = "BBQ Burger", Description = "Dana köfte,barbekü sos,közlenmiş soğan", LastConsumption = Convert.ToDateTime("05.08.2024"), Stock = 20, Price = 200, ImageUrl = "/images/bbqBurger.jpg", isDiscount = true, CategoryId = 3 },
                 new Product() { Id = 4, Name = "Mantarlı Pizza", Description = "Mozarella peyniri,özel sos,mantar", LastConsumption = Convert.ToDateTime("01.08.2024"), Stock = 15, Price = 150, ImageUrl = "/images/mantarlıPizza.jpg", isDiscount = false, CategoryId = 2 },
                 new Product() { Id = 5, Name = "Sucuklu Pizza", Description = "Mozarella peyniri,özel sos,sucuk", LastConsumption = Convert.ToDateTime("02.08.2024"), Stock = 25, Price = 160, ImageUrl = "/images/sucuklupizza.jpg", isDiscount = false, CategoryId = 2 }
                );

            base.OnModelCreating(builder);
        }




    }


}
