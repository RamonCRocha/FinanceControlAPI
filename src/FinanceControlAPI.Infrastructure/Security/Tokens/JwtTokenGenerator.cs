﻿using FinanceControlAPI.Domain.Entities;
using FinanceControlAPI.Domain.Secutiry.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceControlAPI.Infrastructure.Security.Tokens;
internal class JwtTokenGenerator : IAccessTokenGenerator
{
  private readonly uint _expirationTimeMinutes;
  private readonly string _signinKey;

  public JwtTokenGenerator(uint expirationTimeMinutes, string signinKey)
  {
    _expirationTimeMinutes = expirationTimeMinutes;
    _signinKey = signinKey;
  }

  public string Generate(User user)
  {
    var claims = new List<Claim>()
    {
      new Claim(ClaimTypes.Name, user.Name),
      new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString())
    };

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
      SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
      Subject = new ClaimsIdentity(claims)
    };

    var tokenHandler = new JwtSecurityTokenHandler();

    var securityToken = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(securityToken);
  }

  private SymmetricSecurityKey SecurityKey()
  {
    var key = Encoding.UTF8.GetBytes(_signinKey);

    return new SymmetricSecurityKey(key);
  }
}
