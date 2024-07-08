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

		public async Task Add(CategoryViewModel model)
		{
			Category category = new Category();
			category = _mapper.Map<Category>(model);
			await _uow.GetRepository<Category>().Add(category);
			await _uow.CommitAsync();
		}

		public async Task Delete(CategoryViewModel model)
		{
			Category category = new Category();
			category = _mapper.Map<Category>(model);
			_uow.GetRepository<Category>().Delete(category);
			await _uow.CommitAsync();
		}

		public async Task<List<CategoryViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Category>().GetAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(list);
        }

		public async Task Update(CategoryViewModel model)
		{
			Category category = new Category();
			category = _mapper.Map<Category>(model);
			_uow.GetRepository<Category>().Update(category);
			await _uow.CommitAsync();
		}
	}
}
