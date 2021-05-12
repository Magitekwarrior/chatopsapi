using chatopsapi.Infrastructure.Models.MSTeams;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public class MessageCard
  {
    private string _summary;

    [JsonProperty("@type")]
    public string Type
    {
      get
      {
        return "MessageCard";
      }
    }

    [JsonProperty("@context")]
    public string Context
    {
      get
      {
        return "https://schema.org/extensions";
      }
    }

    public string Title { get; }

    public string Text { get; set; }

    public string ThemeColor { get; set; } // e.g. 0076D7 = dark blue

    public string Summary
    {
      get
      {
        if (!string.IsNullOrWhiteSpace(_summary))
        {
          return _summary;
        }
        return string.IsNullOrWhiteSpace(Text) ? Title : null; // We must provide either Text or Summary in the JSON payload
      }
      set
      {
        _summary = value;
      }
    }

    public IEnumerable<Section> Sections { get; set; }

    [JsonProperty("potentialAction")]
    public IEnumerable<MsgAction> Actions { get; set; }

    public MessageCard(string title)
    {
      Title = title;
      Sections = new List<Section>();
      Actions = new List<MsgAction>();
    }

    public string ToJson()
    {
      return JsonConvert.SerializeObject(this, new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
      });
    }
  }
}
