using FoodOrderApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : ICategoryRepository
    {
         private readonly AppDbContext _context;
         public EfCoreCategoryRepository(AppDbContext appDbContext){
            _context = appDbContext;
         }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}