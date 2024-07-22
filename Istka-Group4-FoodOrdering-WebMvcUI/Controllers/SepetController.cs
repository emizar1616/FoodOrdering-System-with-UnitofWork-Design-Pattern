using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Istka_Group4_FoodOrdering_Service.Extensions;
using Istka_Group4_FoodOrdering_Service.Interfaces;

using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Istka_Group4_FoodOrdering_WebMvcUI.Controllers
{
    public class SepetController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISepetDetayService _sepetDetayService;
        List<SepetDetay> sepet;

        public SepetController(IProductService productService, ISepetDetayService sepetDetayService)
        {
            _productService = productService;
            _sepetDetayService = sepetDetayService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                sepet = SepetAl();
                TempData["ToplamAdet"] = _sepetDetayService.ToplamAdet(sepet);

                if (_sepetDetayService.ToplamTutar(sepet) > 0)
                    TempData["ToplamTutar"] = _sepetDetayService.ToplamTutar(sepet);

                return View(sepet);
            }
            TempData["mesaj"] = "Giriş yapılmadı , öncelikli olarak giriş yapınız!";

            return View("MessageShow");

        }
        public async Task<IActionResult> Ekle(int Id, int Adet)
        {

            var product = await _productService.Get(Id);
            sepet = SepetAl();
            SepetDetay siparis = new SepetDetay();
            siparis.ProductId = product.Id;
            siparis.ProductName = product.Name;
            siparis.ProductQuantity = Adet;
            siparis.ProductPrice = product.Price;
            sepet = _sepetDetayService.SepeteEkle(sepet, siparis);
            SepetKaydet(sepet);
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            sepet = SepetAl();
            sepet = _sepetDetayService.SepettenSil(sepet, id);
            SepetKaydet(sepet);
            return RedirectToAction("Index");
        }
        public IActionResult SepetSil()
        {
            //HttpContext.Session.Clear(); //Oturumda bulunan tüm session'ları siler.
            HttpContext.Session.Remove("sepet"); //Sadece ismi belirtilen session'ı siler.
            return RedirectToAction("Index");
        }
        public List<SepetDetay> SepetAl()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetay>>("sepet") ?? new List<SepetDetay>();

            return sepet;
        }
        public void SepetKaydet(List<SepetDetay> sepet)
        {
            HttpContext.Session.SetJson("sepet", sepet);
        }
    }
}
