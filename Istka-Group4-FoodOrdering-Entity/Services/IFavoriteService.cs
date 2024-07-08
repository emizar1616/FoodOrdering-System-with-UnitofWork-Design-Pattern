using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
	public interface IFavoriteService
	{
		Task<List<FavoriteViewModel>> GetAllByUserId(int id);
		Task Add(FavoriteViewModel model);
		Task Delete(FavoriteViewModel model);
		Task Update(FavoriteViewModel model);
	}
}
