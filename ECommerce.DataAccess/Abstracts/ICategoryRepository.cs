using ECommerce.Core.Repositories;
using ECommerce.Models.Entities;

namespace ECommerce.DataAccess.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
  Task<Category?> GetByNameAsync(string name);
}