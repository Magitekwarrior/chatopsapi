using System;

namespace chatopsapi.Infrastructure.DomainExceptions
{
  public class ReplayDomainException : DomainException
  {
    public ReplayDomainException(string message) : base(message)
    {
    }

    public ReplayDomainException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public override string LogMessage
    {
      get
      {
        return "A replay domain validation exception has occurred: " + Message;
      }
    }

    public override bool LogAsInfo
    {
      get
      {
        return true;
      }
    }

  }
}
