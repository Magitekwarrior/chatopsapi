using chatopsapi.Infrastructure.Configurations.ConfigModels;

namespace chatopsapi.Infrastructure.Configurations
{
  public class ConfigService : IConfigService
  {
    private readonly AppSettings _appSettings;
    protected ServicesEndpoints _servicesEndpoints { get; }
    protected ConnectionStrings _connectionStrings { get; }

    public ConfigService(AppSettings appSettings,
      ConnectionStrings connectionStrings,
      ServicesEndpoints servicesEndpoints)
    {
      _appSettings = appSettings;
      _connectionStrings = connectionStrings;
      _servicesEndpoints = servicesEndpoints;
    }

    public string GetNotificationDBConnectionString()
		{
      return _connectionStrings.HcNotificationDB;
    }

    public int GetDefaultConnectionTimeOut()
    {
      var key = _connectionStrings.Timeout;

      return key;
    }

    /// <summary>
    /// Get Service Endpoint
    /// </summary>
    /// <param name="serviceName"></param>
    /// <returns></returns>
    public string GetServiceEndPoint(string serviceName)
    {
      var endpoint = _servicesEndpoints.Services[serviceName].Url;

      return endpoint;
    }

  }
}
