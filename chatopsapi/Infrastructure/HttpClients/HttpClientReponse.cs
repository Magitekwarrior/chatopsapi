using System;
using System.Net.Http;
using chatopsapi.Infrastructure.DomainExceptions;
using chatopsapi.Infrastructure.DomainExceptions.HttpResponse;
using Newtonsoft.Json;

namespace chatopsapi.Infrastructure.HttpClients
{
  public static class HttpClientReponse<T>
  {
    public const int DefaultDomainExceptionHttpCode = 460;
    /// <summary>
    /// Read the message from HttpResponseMessage and throw and ReplayDomainException if we get our internal Http error code: 460
    /// </summary>
    /// <param name="responseMessage"></param>
    /// <returns></returns>
    public static T ReadMessage(HttpResponseMessage responseMessage)
    {
      var responseData = responseMessage.Content.ReadAsStringAsync().Result;

      var httpCode = (int)responseMessage.StatusCode;


      if (httpCode == DefaultDomainExceptionHttpCode) //our domain 
      {
        var httpDomainError = JsonConvert.DeserializeObject<HttpDomainErrorResponse>(responseData);

        throw new ReplayDomainException(httpDomainError.Error.ErrorMessage);
      }
      else if (httpCode >= 400) //Might need to go into more detail here
      {
        throw new Exception(responseData);
      }

      //success
      return JsonConvert.DeserializeObject<T>(responseData);
    }
  }
}
