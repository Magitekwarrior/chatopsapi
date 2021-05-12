using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using chatopsapi.Infrastructure.Configurations;
using chatopsapi.Infrastructure.Models.MSTeams;
using chatopsapi.Infrastructure.Repositories.Contracts.MSTeams;
using chatopsapi.Service.Contracts.MSTeams;
using chatopsapi.ServiceModels;

namespace chatopsapi.Service
{
  public class MSTeamsService : IMSTeamsService
  {
    private readonly IConfigService _configService;
    private readonly IMapper _mapper;    
    private readonly IMSTeamsRepo _msTeamsRepo;

    public MSTeamsService(IConfigService configService,
      IMapper mapper,
      IMSTeamsRepo msTeamsRepo)
    {
      _configService = configService;
      _mapper = mapper;

      _msTeamsRepo = msTeamsRepo;
    }

    public Task<bool> PostNotificationSSIS(NotificationSSIS notification)
    {
      var notificationSection = new Section(string.Empty)
      {
        ImageUrl = notification.ImageUrl, // "https://pbs.twimg.com/profile_images/1262641521637064706/ZCgM2uYi_400x400.jpg",
        Subtitle = notification.NotificationMessage,
      };
      notificationSection.AddFact("PackageName", notification.PackageName);
      notificationSection.AddFact("RunDate", notification.RunDate);
      notificationSection.AddFact("Status", notification.Status);

      var sections = new List<Section>();
      sections.Add(notificationSection);

      var messageCard = new MessageCard(notification.Title)
      {
        Actions = new List<MsgAction>(),
        //Text = notification.NotificationMessage,
        ThemeColor = "0076D7",
        Sections = sections
      };

      var success = _msTeamsRepo.PostMessageCard(messageCard, notification.WebhookUrl);
      return success;
    }

    public Task<bool> PostNotificationSimple(NotificationSimple notification)
    {
      var sections = new List<Section>();
      sections.Add(new Section(string.Empty)
      {
        ImageUrl = notification.ImageUrl, // "https://pbs.twimg.com/profile_images/1262641521637064706/ZCgM2uYi_400x400.jpg",
        Subtitle = notification.NotificationMessage
      });

      var messageCard = new MessageCard(notification.Title)
      {
        Actions = new List<MsgAction>(),
        ThemeColor = "ce1675",
        Sections = sections
      };

      var success = _msTeamsRepo.PostMessageCard(messageCard, notification.WebhookUrl);
      return success;
    }

  }
}
