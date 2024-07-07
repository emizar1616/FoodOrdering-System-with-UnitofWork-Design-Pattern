using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> Get(int id);
        Task Add(ProductViewModel model);

        //Burada edit veya delete yazmamışız. Fakat bunu sonrasında yapabiliyor muyuz ? Servis kısmına eklememiz gerekmiyor mu ? 
    }
}
