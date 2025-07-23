using ECommerce.Core.Entities;

namespace ECommerce.Models.Entities;

public class Category : Entity<int>
{
  public Category()
  {

  }

  public string Name { get; set; } = default!;
  public List<Product>? Products { get; set; }
}