using ECommerce.Models.Entities;

namespace ECommerce.DataAccess.Abstracts;

public interface IOrderRepository
{
  Task<Order> CreateOrderAsync(Order order);
  Task<Order?> GetOrderByIdAsync(int orderId);
}