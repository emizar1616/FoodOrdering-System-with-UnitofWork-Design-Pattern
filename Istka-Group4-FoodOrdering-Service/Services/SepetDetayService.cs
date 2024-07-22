using Istka_Group4_FoodOrdering_Entity.ViewModels;
using Istka_Group4_FoodOrdering_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Services
{
   public class SepetDetayService:ISepetDetayService
    {
        public List<SepetDetay> SepeteEkle(List<SepetDetay> sepet, SepetDetay siparis)
        {
            if (sepet.Any(s => s.ProductId == siparis.ProductId))
            {
                foreach (var item in sepet)
                {
                    //aynı ürünü bulup, miktarını sipariş miktarı kadar artırıyoruz.
                    if (item.ProductId == siparis.ProductId)
                        item.ProductQuantity += siparis.ProductQuantity;
                }
            }
            else
            {
                //yeni ürün, ilk defa sepete atılacak.
                sepet.Add(siparis);
            }
            return sepet;
        }
        public List<SepetDetay> SepettenSil(List<SepetDetay> sepet, int id)
        {
            sepet.RemoveAll(s => s.ProductId == id);
            return sepet;
        }
        public int ToplamAdet(List<SepetDetay> sepet)
        {
            var toplamAdet = sepet.Sum(s => s.ProductQuantity);
            return toplamAdet;
        }
        public decimal ToplamTutar(List<SepetDetay> sepet)
        {
            var toplamTutar = sepet.Sum(s => s.ProductQuantity * s.ProductPrice);
            return toplamTutar;
        }
    }
}
