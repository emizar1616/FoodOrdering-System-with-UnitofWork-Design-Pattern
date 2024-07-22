using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Interfaces
{
   public interface ISepetDetayService
    {
        List<SepetDetay> SepeteEkle(List<SepetDetay> sepet, SepetDetay siparis);
        List<SepetDetay> SepettenSil(List<SepetDetay> sepet, int id);
        int ToplamAdet(List<SepetDetay> sepet);
        decimal ToplamTutar(List<SepetDetay> sepet);
    }
}
