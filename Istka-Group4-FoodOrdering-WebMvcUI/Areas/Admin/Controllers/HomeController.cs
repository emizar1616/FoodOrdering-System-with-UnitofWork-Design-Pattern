using AutoMapper;
using Istka_Group4_FoodOrdering_DataAccess.Contexts;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_WebMvcUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly FoodDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
      
        private readonly IProductSaleService _productSaleService;

        public HomeController(FoodDbContext context, IProductService productService, ICategoryService categoryService,  IProductSaleService productSaleService, IAccountService accountService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
            
            _productSaleService = productSaleService;
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
                ViewBag.SelectedCategoryId = id.Value;
            }
            else
            {
                ViewBag.SelectedCategoryId = null;
            }

            return View(list);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _accountService.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model, IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);
            model.ImageUrl = "/images/" + formFile.FileName;
            await _productService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.Delete(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model, IFormFile? formFile)
        {
            if (formFile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                formFile.CopyTo(stream);
                model.ImageUrl = "/images/" + formFile.FileName;
            }

            await _productService.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult SpecialProductInfo()
        {
            var products = _context.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                LastConsumption = p.LastConsumption,
                Stock = p.Stock,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                isDiscount = p.isDiscount,
                CategoryId = p.CategoryId
            }).ToList();

            return View(products);
        }
        public async Task<IActionResult> ShowSales()
        {
            var list = await _productSaleService.GetAll();
            return View(list);
        }
    }
}
