using ECommerce.Core.Responses;
using ECommerce.Models.Dtos.Tokens.Responses;
using ECommerce.Models.Dtos.Users.Requests;
using ECommerce.Service.Abstracts;

namespace ECommerce.Service.Concretes;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{
  public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequest request)
  {
    var user = await _userService.LoginAsync(request);
    var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

    return new ReturnModel<TokenResponseDto>()
    {
      Data = tokenResponse,
      Message = "Giriş başarılı.",
      StatusCode = 200,
      Success = true
    };
  }

  public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequest request)
  {
    var user = await _userService.RegisterAsync(request);
    var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

    return new ReturnModel<TokenResponseDto>()
    {
      Data = tokenResponse,
      Message = "Kayıt başarılı.",
      StatusCode = 200,
      Success = true
    };
  }
}