using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FeedbackService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task Add(FeedbackViewModel model)
        {
            Feedback feedback = new Feedback();
            feedback = _mapper.Map<Feedback>(model);
            await _uow.GetRepository<Feedback>().Add(feedback);
            await _uow.CommitAsync();
        }
        public async Task<List<FeedbackViewModel>> GetAllByProductId(int id)
        {
            var list = await _uow.GetRepository<Feedback>().GetAll(c => c.ProductId == id);
            return _mapper.Map<List<FeedbackViewModel>>(list);
        }

        public async Task Delete(FeedbackViewModel model)
        {
            Feedback fb = new Feedback();
            fb = _mapper.Map<Feedback>(model);
            _uow.GetRepository<Feedback>().Delete(fb);
            await _uow.CommitAsync();
        }
        public async Task Update(FeedbackViewModel model)
        {
            Feedback fb = new Feedback();
            fb = _mapper.Map<Feedback>(model);
            _uow.GetRepository<Feedback>().Update(fb);
            await _uow.CommitAsync();
        }
    }
}
