using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace chatopsapi.ServiceModels
{
  public class NotificationSimple
  {
    public string Title { get; set; }
    public string NotificationMessage { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string WebhookUrl { get; set; } = string.Empty;
  }
}
