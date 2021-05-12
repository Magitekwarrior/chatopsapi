using System.Threading.Tasks;
using chatopsapi.Infrastructure.Configurations;
using chatopsapi.Infrastructure.HttpClients;
using chatopsapi.Infrastructure.Models.MSTeams;
using chatopsapi.Infrastructure.Repositories.Contracts.MSTeams;

namespace chatopsapi.Infrastructure.Repositories
{
  public class MSTeamsRepo : IMSTeamsRepo
  {
    private readonly string _url;
    private readonly IHttpClientRepo _httpClientRepo;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfigService _configService;

    public MSTeamsRepo(IConfigService configService,
      IHttpClientRepo httpClientRepo,
      IHttpClientFactory httpClientFactory)
    {
      _configService = configService;
      _httpClientRepo = httpClientRepo;
      _httpClientFactory = httpClientFactory;
    }

    public async Task<bool> PostMessageCard(MessageCard card, string webhookUrl)
    {
      var url = (webhookUrl != string.Empty) ? webhookUrl : ConfigurationKeys.MSTeamsTestAlerts;
      var response = await _httpClientRepo.PostToWebApiAsync<MessageCard>(card, url);
      response.EnsureSuccessStatusCode();

      return true;
    }
  }
}
