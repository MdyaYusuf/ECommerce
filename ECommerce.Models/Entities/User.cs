﻿using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models.Entities;

public class User : IdentityUser
{
  public User()
  {

  }

  public string FirstName { get; set; } = default!;
  public string LastName { get; set; } = default!;
  public string City { get; set; } = default!;
  public DateTime? BirthDate { get; set; }
  public ICollection<Order>? Orders { get; set; }
}