namespace ECommerce.Models.Dtos.Carts.Requests;

public sealed record RemoveCartItemRequest(Guid ProductId, int Quantity);