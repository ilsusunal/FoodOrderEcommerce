using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApp.Entity
{
    public class ProductVar
    {
        public int ProductVarId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public List<Material> Materials { get; set; } = new List<Material>();
        public decimal Price { get; set; } 
        public bool IsVegetarian 
        {
            get 
            {
                return Materials.All(m => m.IsVegetarian);
            }
        }
        
    }
}