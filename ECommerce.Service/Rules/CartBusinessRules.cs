using ECommerce.Core.Exceptions;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Rules;

public class CartBusinessRules
{
  public void EnsureCartItemExists(Cart cart, Guid productId)
  {
    var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

    if (item == null)
    {
      throw new BusinessException("Silmek istediğiniz ürün sepette bulunmamaktadır.");
    }
  }
  public void EnsureStockAvailable(Product product, int currentQuantity, int additionalQuantity)
  {
    if (product.Stock < currentQuantity + additionalQuantity)
    {
      throw new BusinessException("Ürün stoğu yeterli değil.");
    }
  }
}