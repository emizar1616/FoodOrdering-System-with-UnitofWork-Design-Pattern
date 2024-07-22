using Istka_Group4_FoodOrdering_DataAccess.Contexts;
using Istka_Group4_FoodOrdering_DataAccess.Identity;
using Istka_Group4_FoodOrdering_DataAccess.Repositories;
using Istka_Group4_FoodOrdering_Entity.Repositories;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Service.Interfaces;
using Istka_Group4_FoodOrdering_Service.Mapping;
using Istka_Group4_FoodOrdering_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.DataAccess.UnitOfWorks;


namespace Wissen.Istka.BlogProject.App.Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;

                opt.User.RequireUniqueEmail = true; //aynı email adresinin girilmesine izin vermez
                                                    // opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789"; //kullanıcı adı girilirken sadece bu karakterlere izin verir.

                opt.Lockout.MaxFailedAccessAttempts = 3; //default =5
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default=5
            }).AddEntityFrameworkStores<FoodDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                // opt.AccessDeniedPath = new PathString("/Account/AccesDenied");

                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk. dolmadan kullanıcı yeniden login olursa süre baştan başlar

                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true
                };
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IProductSaleDetailService, ProductSaleDetailService>();
            services.AddScoped<ISepetDetayService, SepetDetayService>();
            services.AddScoped<IProductSaleService, ProductSaleService>();
           
            services.AddScoped<IInvoiceUserService, InvoiceUserService>();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
