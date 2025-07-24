using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Abstracts;
using ECommerce.DataAccess.Contexts;
using ECommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concretes;

public class EfProductRepository : EfBaseRepository<BaseDbContext, Product, Guid>, IProductRepository
{
  public EfProductRepository(BaseDbContext context) : base(context)
  {

  }

  public async Task<Product?> GetByNameAsync(string name)
  {
    return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
  }

  public async Task ReduceStockAsync(Guid productId, int quantity)
  {
    var product = await GetByIdAsync(productId);

    product.Stock -= quantity;

    Update(product);
  }
}