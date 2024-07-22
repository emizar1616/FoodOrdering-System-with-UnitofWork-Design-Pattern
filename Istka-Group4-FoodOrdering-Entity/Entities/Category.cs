﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        
        public virtual List<Product> Products { get; set; }
    }
}
