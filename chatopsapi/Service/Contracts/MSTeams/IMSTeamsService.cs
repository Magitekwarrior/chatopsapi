using System.Threading.Tasks;
using chatopsapi.ServiceModels;
using chatopsapi.Infrastructure.Models.MSTeams;

namespace chatopsapi.Service.Contracts.MSTeams
{
  public interface IMSTeamsService
  {
    //Task<bool> PostMessageCard(NotificationFull notification);
    Task<bool> PostNotificationSSIS(NotificationSSIS notification);
    Task<bool> PostNotificationSimple(NotificationSimple notification);
  }
}
