using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace chatopsapi.Models.Slack
{
  public class SlackCommandResponse
  {
    /// <summary>
    /// ephemeral or in_channel
    /// </summary>
    [DefaultValue("in_channel")]
    [JsonPropertyName("response_type")]
    public string ResponseType { get; set; }


    [DefaultValue(false)]
    [JsonPropertyName("replace_original")]
    public bool ReplaceOriginal { get; set; }

    [DefaultValue(false)]
    [JsonPropertyName("delete_original")]
    public bool DeleteOriginal { get; set; }

    [JsonPropertyName("blocks")]
    public List<SlackCommandResponseBlock> Blocks { get; set; }
  }

  public class SlackCommandResponseBlock
  {
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
  }
}
