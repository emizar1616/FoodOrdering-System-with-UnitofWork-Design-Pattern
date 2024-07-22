using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.ViewModels
{
   public class InvoiceViewModel
    {
        public UserViewModel userViewModel { get; set; }
        public ProductSaleViewModel satisViewModel { get; set; }
        public List<SepetDetay> sepetDetayListesi { get; set; }
    }
}
