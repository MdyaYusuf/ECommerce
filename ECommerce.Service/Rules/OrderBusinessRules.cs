using ECommerce.Core.Exceptions;
using ECommerce.DataAccess.Abstracts;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Rules;

public class OrderBusinessRules(IOrderRepository _orderRepository)
{
  public void EnsureValidOrder(Order order)
  {
    if (order.Total <= 0)
    {
      throw new BusinessException("Sipariş toplamı sıfırdan büyük olmalıdır.");
    }

    if (string.IsNullOrWhiteSpace(order.OrderDetails))
    {
      throw new BusinessException("Sipariş detayı boş olamaz.");
    }
  }

  public async Task IsOrderExistAsync(int orderId)
  {
    var order = await _orderRepository.GetOrderByIdAsync(orderId);

    if (order == null)
    {
      throw new NotFoundException($"{orderId} numaralı sipariş bulunamadı.");
    }
  }
}