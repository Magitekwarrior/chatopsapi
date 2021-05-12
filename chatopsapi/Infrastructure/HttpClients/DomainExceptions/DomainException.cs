using chatopsapi.Infrastructure.DomainExceptions.HttpResponse;
using Newtonsoft.Json;
using System;

namespace chatopsapi.Infrastructure.DomainExceptions
{
  public class DomainException : BaseException
  {
    public DomainException(string message) : base(message)
    {

    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {

    }


    public override string GetHttpDomainErrorResponse()
    {
      var httpDomainErrorResponse = new HttpDomainErrorResponse()
      {
        Error = new Error() { ErrorMessage = Message }
      };

      var jsonResponse = JsonConvert.SerializeObject(httpDomainErrorResponse);

      return jsonResponse;
    }

    public override string LogMessage
    {
      get
      {
        return "A domain validation exception has occurred: " + Message;
      }
    }

    //public override bool LogAsInfo
    //{
    //  get { return true; }
    //}



    public override int HttpErrorCode
    {
      get { return 460; }
    }

  }
}
