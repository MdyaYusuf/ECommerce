using ECommerce.DataAccess.Abstracts;
using ECommerce.DataAccess.Contexts;
using ECommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Concretes;

public class EfOrderRepository : IOrderRepository
{
  protected BaseDbContext _context;
  public EfOrderRepository(BaseDbContext context)
  {
    _context = context;
  }

  public async Task<Order> CreateOrderAsync(Order order)
  {
    await _context.Orders.AddAsync(order);

    return order;
  }

  public async Task<Order?> GetOrderByIdAsync(int orderId)
  {
    return await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
  }
}