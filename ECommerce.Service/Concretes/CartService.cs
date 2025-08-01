﻿using ECommerce.Core.Exceptions;
using ECommerce.Models.Entities;
using ECommerce.Service.Abstracts;
using ECommerce.Service.Rules;

namespace ECommerce.Service.Concretes;

public class CartService(CartBusinessRules _businessRules) : ICartService
{
  public void AddItem(Cart cart, Product product, int quantity)
  {
    if (quantity <= 0)
    {
      throw new BusinessException("Adet sayısı sıfırdan büyük olmalıdır.");
    }

    var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == product.Id);
    int currentQuantity = existingItem?.Quantity ?? 0;

    _businessRules.EnsureStockAvailable(product, currentQuantity, quantity);

    if (existingItem != null)
    {
      existingItem.Quantity += quantity;
    }
    else
    {
      cart.CartItems.Add(new CartItem()
      {
        ProductId = product.Id,
        ProductName = product.Name,
        ImageUrl = product.ImageUrl,
        UnitPrice = product.Price,
        Quantity = quantity
      });
    }
  }

  public void RemoveItem(Cart cart, Guid productId, int quantity)
  {
    _businessRules.EnsureCartItemExists(cart, productId);

    var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

    if (item != null)
    {
      if (quantity >= item.Quantity)
      {
        cart.CartItems.Remove(item);
      }
      else
      {
        item.Quantity -= quantity;
      }
    }
  }

  public void ClearCart(Cart cart)
  {
    cart.CartItems.Clear();
  }
}