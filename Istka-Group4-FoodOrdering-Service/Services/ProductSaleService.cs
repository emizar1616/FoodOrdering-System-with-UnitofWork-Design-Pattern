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
	public class ProductSaleService : IProductSaleService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public ProductSaleService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}

		public async Task Add(ProductSaleViewModel model)
		{
			ProductSale pSale = new ProductSale();
			pSale = _mapper.Map<ProductSale>(model);
			await _uow.GetRepository<ProductSale>().Add(pSale);
			await _uow.CommitAsync();
		}

		public async Task<ProductSaleViewModel> Get(int id)
		{
			var productSale = await _uow.GetRepository<ProductSale>().GetByIdAsync(id);
			return _mapper.Map<ProductSaleViewModel>(productSale);
		}

		public async Task<List<ProductSaleViewModel>> GetAll()
		{
			var list = await _uow.GetRepository<ProductSale>().GetAllAsync();
			return _mapper.Map<List<ProductSaleViewModel>>(list);
		}
	}
}
