namespace chatopsapi.ServiceModels
{
  public class NotificationSSIS
  {
    public string ImageUrl { get; set; } = string.Empty;
    public string WebhookUrl { get; set; } = string.Empty;

    public string NotificationMessage { get; set; }
    public string Environment { get; set; }
    public string Title { get; set; }
    public string PackageName { get; set; }
    public string RunDate { get; set; }
    public string Status { get; set; }
  }

}