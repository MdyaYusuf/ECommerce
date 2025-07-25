using ECommerce.Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Utils;

public static class IdentityResultHelper
{
  public static void Check(IdentityResult result)
  {
    if (!result.Succeeded)
    {
      throw new BusinessException(result.Errors.First().Description);
    }
  }
}