using chatopsapi.Infrastructure.Models.MSTeams;

namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public class DateInput : Input
  {
    public bool IncludeTime { get; set; }

    public DateInput() : base("DateInput")
    {

    }
  }
}
