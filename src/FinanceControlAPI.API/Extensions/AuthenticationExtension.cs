using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FinanceControlAPI.API.Extensions;

public static class AuthenticationExtension
{
  public static void AddProjectConfigurations(this IServiceCollection services, IConfiguration configuration)
  {
    ConfigureJwtAuthentication(services, configuration);
    ConfigureSwagger(services);
  }

  private static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
  {
    var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

    services.AddAuthentication(config =>
    {
      config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(config =>
    {
      config.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
      };
    });
  }

  private static void ConfigureSwagger(IServiceCollection services)
  {
    services.AddSwaggerGen(config =>
    {
      config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Name = "Authorization",
        Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 1234abcdef'",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey
      });
      config.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
            {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
          },
           new List<string>()
        }
      });
    });
  }
}
