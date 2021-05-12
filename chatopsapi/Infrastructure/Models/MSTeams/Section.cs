using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public class Section
  {
    public List<Fact> Facts { get; set; }

    public string Text { get; }

    [JsonProperty("activityTitle")]
    public string Title { get; set; }

    [JsonProperty("activitySubTitle")]
    public string Subtitle { get; set; }

    [JsonProperty("activityImage")]
    public string ImageUrl { get; set; }

    public bool StartGroup { get; set; }

    public Guid? CorrelationId { get; set; }

    public string Color { get; set; }

    public bool Markdown { get; set; } = true;

    public Section(string text)
    {
      Facts = new List<Fact>();
      Text = text;
    }

    public void AddFact(string name, string value)
    {
      Facts.Add(new Fact(name, value));
    }
  }
}
