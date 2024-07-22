using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Istka_Group4_FoodOrdering_Service.Extensions;
using Istka_Group4_FoodOrdering_Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Istka_Group4_FoodOrdering_WebMvcUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IProductSaleDetailService _productSaleDetailService;
        private readonly IProductSaleService _productSaleService;
        private readonly IAccountService _accountService;
        private readonly ISepetDetayService _sepetDetayService;

        public PaymentController(IProductSaleDetailService productSaleDetailService, IProductSaleService productSaleService, IAccountService accountService, ISepetDetayService sepetDetayService)
        {
            _productSaleDetailService = productSaleDetailService;
            _productSaleService = productSaleService;
            _accountService = accountService;
            _sepetDetayService = sepetDetayService;

        }
        public IActionResult ConfirmAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmAddress(UserViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["FirstName"] = model.Name;
                TempData["Email"] = model.Email;
                TempData["PhoneNumber"] = model.PhoneNumber;
                TempData["Address"] = model.Address;
                return RedirectToAction("ConfirmPayment");
            }
            TempData["mesaj"] = "Giriş yapılmadı , öncelikli olarak giriş yapınız!";

            return View("MessageShow");
        }

        public async Task<IActionResult> ConfirmPayment()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
            int toplamAdet = _sepetDetayService.ToplamAdet(sepet);
            decimal toplamTutar = _sepetDetayService.ToplamTutar(sepet);

            var username = User.Identity.Name;
            var user = await _accountService.Find(username);
            ProductSaleViewModel pSale = new ProductSaleViewModel()
            {
                Date = DateTime.Now,
                Quantity = toplamAdet,
                Price = toplamTutar,
            };
            InvoiceViewModel model = new InvoiceViewModel()
            {
                userViewModel = await _accountService.Find(username),
                satisViewModel = pSale,
                sepetDetayListesi = sepet,
            };
            model.userViewModel.Name = TempData["FirstName"]?.ToString();
            model.userViewModel.Email = TempData["Email"]?.ToString();
            model.userViewModel.PhoneNumber = TempData["PhoneNumber"]?.ToString();
            model.userViewModel.Address = TempData["Address"]?.ToString();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Sale()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet");
            int toplamAdet = _sepetDetayService.ToplamAdet(sepet);
            decimal toplamTutar = _sepetDetayService.ToplamTutar(sepet);

            var username = User.Identity.Name;
            var user = await _accountService.Find(username);
            ProductSaleViewModel productSaleViewModel = new ProductSaleViewModel();

            productSaleViewModel.UserId = user.Id;
            productSaleViewModel.Date = DateTime.Now;
            productSaleViewModel.Quantity = toplamAdet;
            productSaleViewModel.Price = toplamTutar;

            var satisId = _productSaleService.AddSale(productSaleViewModel);
            bool state = _productSaleDetailService.AddRange(sepet, satisId);

            if (state == false)
            {
                TempData["mesaj"] = "Satış işlemi başarıyla tamamlandı.";
                HttpContext.Session.Remove("sepet"); //Sepet bilgileri session'dan silinir. Ancak müşteri isterse yeniden alışverişe devam edebilir.
            }
            else
            {
                TempData["mesaj"] = "Satış işlemi tamamlanamadı. Bilgilerinizi kontrol ediniz.";
            }



            //Satılan ürünlerin (movieSaleDetail.MovieId) stok miktarları satış adetleri kadar eksiltilmeli.

            return View("MessageShow");
            //return RedirectToAction("Invoice", new { saleId = satisId });
        }

        //public async Task<IActionResult> Invoice(int saleId)
        //{
        //    var sale = await _productSaleService.Get(saleId);
        //    var username = User.Identity.Name;
        //    var user = await _accountService.FindByNameForUsers(username);
        //    var saleDetails = await _productSaleDetailService.GetByProductSaleId(saleId);

        //    InvoiceViewModel model = new InvoiceViewModel
        //    {
        //        userViewModel = user,
        //        satisViewModel = sale,
        //        //sepetDetayListesi = saleDetails
        //    };

        //    return View(model);
        //}
    }
}




