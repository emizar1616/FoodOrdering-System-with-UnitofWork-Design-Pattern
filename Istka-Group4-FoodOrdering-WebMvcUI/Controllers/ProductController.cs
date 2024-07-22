using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Entities;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Istka_Group4_FoodOrdering_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Istka_Group4_FoodOrdering_WebMvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IFeedbackService _feedbackService;
        private readonly IAccountService _accountService;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper, IFeedbackService feedbackService, IAccountService accountService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _feedbackService = feedbackService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index(int? id, string? search)
        {
            var list = await _productService.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(a => a.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }

            if (id.HasValue)
            {
                list = list.Where(p => p.CategoryId == id.Value).ToList();
                ViewBag.SelectedCategoryId = id.Value; // Seçili kategoriyi ViewBag ile gönder
            }
            else
            {
                ViewBag.SelectedCategoryId = null;
            }

            return View(list);
        }


        

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Feedbacks = await _feedbackService.GetAllByProductId(id); // Article Cont-Details e bak
            var product = await _productService.Get(id);
           // ViewBag.SelectedCategoryId = product.CategoryId; // Seçili kategoriyi ViewBag ile gönder.2kez yapıyorum burda viewbag kullanımını
            return View(product);

        }


        public async Task<IActionResult> CreateFeedback(string message, int id)
        {
            var user = await _accountService.Find(User.Identity.Name);
            FeedbackViewModel model = new()
            {
                ProductId = id,
                Description = message,
                UserId = user.Id

            };

            await _feedbackService.Add(model);
            return RedirectToAction("Index");


            //try
            //{
            //    var user = await _accountService.Find(User.Identity.Name);
            //    FeedbackViewModel model = new()
            //    {
            //        ProductId = id,
            //        Description = message,
            //        UserId = user.Id
            //    };

            //    await _feedbackService.Add(model);
            //    return RedirectToAction("Details", new { id });
            //}
            //catch (Exception ex)
            //{
            //    // Hata mesajını loglayın veya kullanıcıya gösterin
            //    Console.WriteLine($"Yorum eklenirken bir hata oluştu: {ex.Message}");
            //    return RedirectToAction("Details", new { id });
            //}
        }




        


        






    }
}
