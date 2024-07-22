using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Istka_Group4_FoodOrdering_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Istka_Group4_FoodOrdering_WebMvcUI.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public CategoriesViewComponent(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          //Viewbag.SelectedCategoryId = RouteData?.Values["id"];
           var categories = await _categoryService.GetAll();
           return View(_mapper.Map<List<CategoryViewModel>>(categories));
        }
    }
}


