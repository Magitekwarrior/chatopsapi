namespace chatopsapi.Infrastructure.Configurations
{
  public class ConfigurationKeys
  {
    // Service Endpoints
    public static string HcOrcCustomer = "HC.ORC.Customer";

    // MSTeams Notification Hook
    public static string MSTeamsTestAlerts = "MSTeams.HCEngineering.TestAlerts";

    // Secret keys
    public static string NotificationJWTSecret = "NotificationJWTSecret";

    // DB Connections
    public static string SupportDBMySql = "HcNotificationDB";
  }
}
