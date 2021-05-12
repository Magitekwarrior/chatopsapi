using Newtonsoft.Json;

namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public abstract class MsgAction
  {
    [JsonProperty("@type")]
    public string Type { get; }

    public string Name { get; }

    protected MsgAction(string type, string name)
    {
      Type = type;
      Name = name;
    }
  }
}
