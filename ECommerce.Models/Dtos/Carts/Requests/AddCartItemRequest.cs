﻿namespace ECommerce.Models.Dtos.Carts.Requests;

public sealed record AddCartItemRequest(Guid ProductId, int Quantity);