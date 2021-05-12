using System.Threading.Tasks;
using chatopsapi.Infrastructure.Models.MSTeams;

namespace chatopsapi.Infrastructure.Repositories.Contracts.MSTeams
{
  public interface IMSTeamsRepo
  {
    Task<bool> PostMessageCard(MessageCard card, string webhookUrl);
  }
}
