using System.Threading.Tasks;
using chatopsapi.Infrastructure.Configurations;
using chatopsapi.Service.Contracts.MSTeams;
using chatopsapi.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace chatopsapi.Controllers
{
  [Produces("application/json")]
  [ApiExplorerSettings(IgnoreApi = false)] // Hides this controller from swagger
  [ApiController]
  [Route("api/[controller]")]
  public class NotificationsController : Controller
  {
    private readonly IConfigService _configService;
    private readonly IMSTeamsService _msTeamService;

    public NotificationsController(IConfigService configService,
      IMSTeamsService msTeamService)
    {
      _configService = configService;
      _msTeamService = msTeamService;
    }

    [HttpPost]
    [Route("PostSSISMessage")]
    public async Task<IActionResult> PostSSISMessage([FromBody] NotificationSSIS messageCard)
    {
      var success = await _msTeamService.PostNotificationSSIS(messageCard);

      if (success)
        return Ok("SSIS notification Card added.");
      else
        return BadRequest(new { message = "Failed to add new SSIS notification card." });
    }

    [HttpPost]
    [Route("PostSimpleMessage")]
    public async Task<IActionResult> PostSimpleMessage([FromBody] NotificationSimple messageCard)
    {
      var success = await _msTeamService.PostNotificationSimple(messageCard);

      if (success)
        return Ok("Simple notification Card added.");
      else
        return BadRequest(new { message = "Failed to add new simple notification card." });
    }
  }
}
