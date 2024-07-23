using FoodOrderApp.Data.Abstract;
using FoodOrderApp.Data.Concrete.EfCore;
using FoodOrderApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderApp.Data.Concrete
{
    public class EfCoreProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public EfCoreProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p => p.Category)
                                          .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.ProductId);
            if (existingProduct == null)
            {
                return null;
            }
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}