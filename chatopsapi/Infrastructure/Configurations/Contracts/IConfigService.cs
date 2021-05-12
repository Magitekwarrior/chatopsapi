namespace chatopsapi.Infrastructure.Configurations
{
  public interface IConfigService
  {
    string GetNotificationDBConnectionString();
    int GetDefaultConnectionTimeOut();
    string GetServiceEndPoint(string serviceName);
  }
}
