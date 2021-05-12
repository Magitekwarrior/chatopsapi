using System.Collections.Generic;
using chatopsapi.Infrastructure.Models.MSTeams;
using chatopsapi.Models.Contracts.MSTeams;

namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public class ActionCard : MsgAction
  {
    public List<Input> Inputs { get; set; }

    public List<INestableAction> Actions { get; set; }

    public ActionCard(string name) : base("ActionCard", name)
    {
      Actions = new List<INestableAction>();
      Inputs = new List<Input>();
    }
  }
}
