using FoodOrderApp.Entity;

namespace FoodOrderApp.Data.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task AddAsync(Product product);
        Task GetByIdAsync(int id);
    }
}