using ECommerce.Models.Dtos.Tokens.Responses;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Abstracts;

public interface IJwtService
{
  Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}