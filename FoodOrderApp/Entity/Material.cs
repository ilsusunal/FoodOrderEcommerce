using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Entity
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
    }
}