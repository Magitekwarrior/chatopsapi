using System.Collections.Generic;
using chatopsapi.Infrastructure.Models.MSTeams;

namespace chatopsapi.Models.Contracts.MSTeams
{
  public class OpenUriAction : MsgAction, INestableAction
  {
    public OpenUriAction(string name) : base("OpenUri", name)
    {
      Targets = new List<Target>();
    }

    public List<Target> Targets { get; set; }

  }
}
