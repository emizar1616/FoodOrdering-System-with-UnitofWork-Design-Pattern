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
	public class ProductSaleDetailService : IProductSaleDetailService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public ProductSaleDetailService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}

		public async Task Add(ProductSaleDetailViewModel model)
		{
			ProductSaleDetail pSaleDetail = new ProductSaleDetail();
			pSaleDetail = _mapper.Map<ProductSaleDetail>(model);
			await _uow.GetRepository<ProductSaleDetail>().Add(pSaleDetail);
			await _uow.CommitAsync();
		}

		public async Task<List<ProductSaleDetailViewModel>> GetAll()
		{
			var list = await _uow.GetRepository<ProductSaleDetail>().GetAllAsync();
			return _mapper.Map<List<ProductSaleDetailViewModel>>(list);
		}

		public async Task<List<ProductSaleDetailViewModel>> GetByProductSaleId(int id)
		{
			var list = await _uow.GetRepository<ProductSaleDetail>().GetAll(c => c.ProductSaleId == id);
			return _mapper.Map<List<ProductSaleDetailViewModel>>(list);
		}
	}
}
