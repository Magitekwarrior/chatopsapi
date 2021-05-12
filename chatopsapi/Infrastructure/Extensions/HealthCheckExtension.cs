using chatopsapi.Infrastructure.Configurations.ConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace chatopsapi.Infrastructure.Extensions
{
  public static class HealthCheckExtension
  {
    public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration Configuration)
    {
      //RedisConfiguration redisConfig = new RedisConfiguration();
      //Configuration.GetSection("RedisServer").Bind(redisConfig);

      //.AddRedis(redisConnectionString: redisConfig.Connection, failureStatus: HealthStatus.Degraded);

    }

    public static void UseCustomHealthChecks(this IApplicationBuilder app)
    {


    }

  }
}