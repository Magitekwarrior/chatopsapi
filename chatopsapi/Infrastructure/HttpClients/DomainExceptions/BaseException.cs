using System;
using System.Net;

namespace chatopsapi.Infrastructure.DomainExceptions
{
  public abstract class BaseException : Exception
  {
    public BaseException()
    {

    }

    public BaseException(string message) : base(message)
    {

    }

    public BaseException(string message, Exception innerException) : base(message, innerException)
    {

    }

    public virtual string GetHttpDomainErrorResponse()
    {
      return String.Empty;
    }

    public virtual string LogMessage
    {
      get
      {
        return Message;
      }
    }

    public virtual bool LogAsInfo
    {
      get
      {
        return false;
      }
    }

    public virtual int HttpErrorCode
    {
      get
      {
        return (int)HttpStatusCode.BadRequest;
      }
    }

  }
}
