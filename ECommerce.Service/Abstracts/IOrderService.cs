using ECommerce.Core.Responses;
using ECommerce.Models.Dtos.Orders.Requests;
using ECommerce.Models.Dtos.Orders.Responses;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Abstracts;

public interface IOrderService
{
  Task<ReturnModel<OrderResponseDto>> CreateOrderAsync(CreateOrderRequest request, Cart cart, string userId);

  Task<ReturnModel<OrderResponseDto>> GetOrderByIdAsync(int orderId);
}