using AutoMapper;
using ECommerce.Core.Responses;
using ECommerce.DataAccess.Abstracts;
using ECommerce.Models.Dtos.Orders.Requests;
using ECommerce.Models.Dtos.Orders.Responses;
using ECommerce.Models.Entities;
using ECommerce.Service.Abstracts;
using ECommerce.Service.Rules;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.Json;

namespace ECommerce.Service.Concretes;

public class OrderService(IOrderRepository _orderRepository, IUnitOfWork _unitOfWork, IMapper _mapper, OrderBusinessRules _businessRules, IProductService _productService) : IOrderService
{
  public async Task<ReturnModel<OrderResponseDto>> CreateOrderAsync(CreateOrderRequest request, Cart cart, string userId)
  {
    using (IDbContextTransaction transaction = await _unitOfWork.BeginTransactionAsync())
    {
      try
      {
        var order = new Order()
        {
          UserId = userId,
          OrderDate = DateTime.Now,
          Total = cart.CartItems.Sum(item => item.UnitPrice * item.Quantity),
          Adress = request.Adress,
          OrderDetails = JsonSerializer.Serialize(cart.CartItems)
        };

        _businessRules.EnsureValidOrder(order);

        foreach (var cartItem in cart.CartItems)
        {
          await _productService.ReduceStockAsync(cartItem.ProductId, cartItem.Quantity);
        }

        await _orderRepository.CreateOrderAsync(order);

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<OrderResponseDto>(order);

        return new ReturnModel<OrderResponseDto>()
        {
          Success = true,
          Message = "Sipariş başarıyla oluşturuldu.",
          Data = response,
          StatusCode = 201
        };
      }
      catch
      {
        await transaction.RollbackAsync();

        throw;
      }
    }
  }

  public async Task<ReturnModel<OrderResponseDto>> GetOrderByIdAsync(int orderId)
  {
    await _businessRules.IsOrderExistAsync(orderId);

    var order = await _orderRepository.GetOrderByIdAsync(orderId);

    var response = _mapper.Map<OrderResponseDto>(order);

    return new ReturnModel<OrderResponseDto>()
    {
      Success = true,
      Message = "Sipariş başarıyla getirildi.",
      Data = response,
      StatusCode = 200
    };
  }
}