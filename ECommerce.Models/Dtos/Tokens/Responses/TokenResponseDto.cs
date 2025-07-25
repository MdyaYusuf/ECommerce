﻿namespace ECommerce.Models.Dtos.Tokens.Responses;

public sealed class TokenResponseDto
{
  public string Username { get; set; } = string.Empty;
  public string AccessToken { get; set; }
  public DateTime AccessTokenExpiration { get; set; }
}