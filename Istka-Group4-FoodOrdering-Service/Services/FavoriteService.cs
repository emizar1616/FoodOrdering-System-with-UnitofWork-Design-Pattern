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
	public class FavoriteService : IFavoriteService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		public FavoriteService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}
		public async Task Add(FavoriteViewModel model)
		{
			Favorite fav = new Favorite();
			fav = _mapper.Map<Favorite>(model);
			await _uow.GetRepository<Favorite>().Add(fav);
			await _uow.CommitAsync();
		}

		public async Task Delete(FavoriteViewModel model)
		{
			Favorite fav = new Favorite();
			fav = _mapper.Map<Favorite>(model);
			_uow.GetRepository<Favorite>().Delete(fav);
			await _uow.CommitAsync();
		}

		public async Task Update(FavoriteViewModel model)
		{
			Favorite fav = new Favorite();
			fav = _mapper.Map<Favorite>(model);
			_uow.GetRepository<Favorite>().Update(fav);
			await _uow.CommitAsync();
		}

		public async Task<List<FavoriteViewModel>> GetAllByUserId(int id)
		{
			var list = await _uow.GetRepository<Favorite>().GetAll(c => c.UserId == id);
			return _mapper.Map<List<FavoriteViewModel>>(list);
		}
	}
}
