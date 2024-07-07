using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Services
{
    public interface IFeedbackService
    {
        Task<List<FeedbackViewModel>> GetAllByProductId(int id);
        Task Update(FeedbackViewModel model);
        Task Delete(FeedbackViewModel model);
        Task Add(FeedbackViewModel model);
    }
}
