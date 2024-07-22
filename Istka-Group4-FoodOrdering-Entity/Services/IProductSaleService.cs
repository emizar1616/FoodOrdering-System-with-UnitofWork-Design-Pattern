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
        Task Add(ProductSaleViewModel model); // bu satış sayfasına sepeti gönderiyor 
        int AddSale(ProductSaleViewModel model); // bu ise yaptığın satış içerisindeki ürünlerin teker teker ne kadar satıldığını satışdetay sayfasına gönderiyor
    }
}
