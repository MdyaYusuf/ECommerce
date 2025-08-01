﻿namespace ECommerce.Models.Dtos.Products.Requests;

public sealed record UpdateProductRequest(Guid Id, string Name, string Description, string ImageUrl, decimal Price, int Stock, bool IsActive, int CategoryId);