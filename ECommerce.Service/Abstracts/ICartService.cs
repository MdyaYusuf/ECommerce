using ECommerce.Models.Entities;

namespace ECommerce.Service.Abstracts;

public interface ICartService
{
  void AddItem(Cart cart, Product product, int quantity);

  void RemoveItem(Cart cart, Guid productId, int quantity);

  void ClearCart(Cart cart);
}