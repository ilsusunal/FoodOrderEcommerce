using FoodOrderApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrderApp.Data.Abstract
{
    public interface IUserRepository<T> where T : class
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(string id);
    }
}
