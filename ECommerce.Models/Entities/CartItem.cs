﻿namespace ECommerce.Models.Entities;

public class CartItem
{
  public CartItem()
  {

  }

  public Guid ProductId { get; set; }
  public string ProductName { get; set; }
  public string ImageUrl { get; set; }
  public decimal UnitPrice { get; set; }
  public int Quantity { get; set; }
}