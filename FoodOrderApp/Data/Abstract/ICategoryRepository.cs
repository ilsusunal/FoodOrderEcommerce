using FoodOrderApp.Entity;
using System.Collections.Generic;

namespace FoodOrderApp.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
