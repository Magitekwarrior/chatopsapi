using chatopsapi.Infrastructure.Configurations;
using chatopsapi.Infrastructure.Configurations.ConfigModels;
using chatopsapi.Infrastructure.HttpClients;
using chatopsapi.Infrastructure.OriginSQL;
using chatopsapi.Infrastructure.OriginSQL.Contracts;
using chatopsapi.Infrastructure.Repositories;
using chatopsapi.Infrastructure.Repositories.Contracts.MSTeams;
using chatopsapi.Service;
using chatopsapi.Service.Contracts.MSTeams;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace chatopsapi.Infrastructure.Extensions
{
  public static class DependencyInjectionExtension
	{
		public static void AddCustomConfigurationDI(this IServiceCollection services, IConfiguration Configuration)
		{
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));			
			services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
			services.Configure<ServicesEndpoints>(Configuration.GetSection("ServicesEndpoints"));

			services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<AppSettings>>().Value);
			services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ConnectionStrings>>().Value);
			services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ServicesEndpoints>>().Value);
		}

		public static void AddCustomServicesDI(this IServiceCollection services)
		{
			services.AddTransient<IConfigService, ConfigService>();			
			services.AddTransient<IMSTeamsService, MSTeamsService>();
		}

		public static void AddCustomInfrastructureDI(this IServiceCollection services)
		{
			services.AddTransient<HttpClients.IHttpClientFactory, HttpClientFactory>();
			services.AddTransient<IHttpClientRepo, HttpClientRepo>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<IOriginSQLUserService, OriginSQLUserService>();
			services.AddTransient<IOriginSQLPasswordService, OriginSQLPasswordService>();

			services.AddTransient<IMSTeamsRepo, MSTeamsRepo>();
		}		
	}
}