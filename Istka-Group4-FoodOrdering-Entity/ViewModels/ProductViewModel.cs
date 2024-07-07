using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastConsumption { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool isDiscount { get; set; }
        public int CategoryId { get; set; }

    }
}
