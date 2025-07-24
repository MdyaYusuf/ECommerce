using ECommerce.Core.Repositories;
using ECommerce.Models.Entities;

namespace ECommerce.DataAccess.Abstracts;

public interface IProductRepository : IRepository<Product, Guid>
{
  Task<Product?> GetByNameAsync(string name);
  Task ReduceStockAsync(Guid productId, int quantity);
}