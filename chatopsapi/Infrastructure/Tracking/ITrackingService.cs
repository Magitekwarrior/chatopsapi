using Microsoft.AspNetCore.Http;

namespace chatopsapi.Infrastructure.Tracking
{
  public interface ITrackingService
  {
    string GetTrackingIdHeaderFieldName();
    string GetTrackingIdForContext();
    void AddTrackingIdToContext(HttpContext context);
  }
}