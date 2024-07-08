using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Entities
{
    public class ProductSale : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }

        //public virtual User User { get; set; }       

        public virtual ProductSaleDetail ProductSaleDetails { get; set; }     
    }
}
