using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.ViewModels
{
    public class ProductSaleDetailViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int ProductSaleId { get; set; }
    }
}
