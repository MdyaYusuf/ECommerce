using ECommerce.Core.Exceptions;
using ECommerce.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Service.Rules;

public class RoleBusinessRules
{
  private readonly RoleManager<IdentityRole> _roleManager;
  public RoleBusinessRules(RoleManager<IdentityRole> roleManager)
  {
    _roleManager = roleManager;
  }

  public void EnsureUserExist(User user)
  {
    if (user == null)
    {
      throw new NotFoundException("Kullanıcı bulunamadı.");
    }
  }

  public void EnsureRoleExist(IdentityRole role)
  {
    if (role == null)
    {
      throw new NotFoundException("Rol bulunamadı.");
    }
  }

  public async Task IsRoleUniqueAsync(string roleName)
  {
    var role = await _roleManager.FindByNameAsync(roleName);

    if (role != null)
    {
      throw new BusinessException("Eklemek istediğiniz rol benzersiz olmalıdır.");
    }
  }
}