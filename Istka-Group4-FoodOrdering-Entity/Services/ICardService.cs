using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
    public interface ICardService
    {
        Task<List<CardViewModel>> GetAllByProductId(int id);
        Task Update(CardViewModel model);
        Task Delete(CardViewModel model);
        Task Add(CardViewModel model);
    }
}
