using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }   
        public async Task<List<CategoryViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Category>().GetAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(list);
        }
    }
}
