using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
	public interface IProductSaleDetailService
	{
		Task<List<ProductSaleDetailViewModel>> GetAll();
		Task Add(ProductSaleDetailViewModel model);
		Task<List<ProductSaleDetailViewModel>> GetByProductSaleId(int id);

	}
}
