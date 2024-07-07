using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Favorite,FavoriteViewModel>().ReverseMap();
            CreateMap<Feedback,FeedbackViewModel>().ReverseMap();
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<ProductSale,ProductSaleViewModel>().ReverseMap();
            CreateMap<ProductSaleDetail , ProductSaleDetailViewModel>().ReverseMap();
        }

    }
}
