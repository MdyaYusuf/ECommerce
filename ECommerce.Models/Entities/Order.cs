﻿namespace ECommerce.Models.Entities;

public class Order
{
  public Order()
  {

  }

  public int Id { get; set; }
  public DateTime OrderDate { get; set; }
  public decimal Total { get; set; }
  public string Adress { get; set; } = string.Empty;
  public string OrderDetails { get; set; } = string.Empty;
  public string UserId { get; set; } = string.Empty;
  public User User { get; set; } = null!;
}