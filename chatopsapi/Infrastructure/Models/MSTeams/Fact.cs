namespace chatopsapi.Infrastructure.Models.MSTeams
{
  public class Fact
  {
    public string Name { get; }

    public string Value { get; }

    public Fact(string name, string value)
    {
      Name = name;
      Value = value;
    }
  }
}
