using System.Collections.Generic;

namespace chatopsapi.Infrastructure.Configurations.ConfigModels
{
	public class ConnectionStrings
	{
    public string CallCentreDB { get; set; }
    public string HcNotificationDB { get; set; }
    public string OmegaDB { get; set; }

    public int Timeout { get; set; }
    public int MaxRetries { get; set; }
  }
}
