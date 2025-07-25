using ECommerce.Core.Responses;
using ECommerce.Models.Dtos.Tokens.Responses;
using ECommerce.Models.Dtos.Users.Requests;

namespace ECommerce.Service.Abstracts;

public interface IAuthenticationService
{
  Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequest request);
  Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequest request);
}