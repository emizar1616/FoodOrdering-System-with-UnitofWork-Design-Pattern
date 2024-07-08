using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
	public interface IProductSaleService
	{
		Task<List<ProductSaleViewModel>> GetAll();
		Task<ProductSaleViewModel> Get(int id);
		Task Add(ProductSaleViewModel model);
		
	}
}
