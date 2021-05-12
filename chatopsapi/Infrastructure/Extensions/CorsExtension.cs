using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace chatopsapi.Infrastructure.Extensions
{
  public static class CorsExtension
  {
    public static void UseCustomCors(this IApplicationBuilder app, IConfiguration configuration)
    {
      string[] headers = configuration.GetSection("CORSSettings:AllowHeaders").Get<string[]>();
      string[] origins = configuration.GetSection("CORSSettings:AllowOrigins").Get<string[]>();
      string[] methods = configuration.GetSection("CORSSettings:AllowMethods").Get<string[]>();

      bool allowCredentials = configuration.GetSection("CORSSettings:AllowCredentials").Get<bool>();

      app.UseCors(options =>
      {
        options
            .WithHeaders(headers)
            .WithMethods(methods)
            .WithOrigins(origins);

        // Unable to allow credentials if the "*" wildcard is used for origins
        if (!origins.Contains("*") && allowCredentials)
        {
          options.AllowCredentials();
        }
      });
    }
  }
}
