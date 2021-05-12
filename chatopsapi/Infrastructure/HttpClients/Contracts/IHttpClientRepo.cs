using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace chatopsapi.Infrastructure.HttpClients
{
  public interface IHttpClientRepo
  {
    Response PostToWebApi<Request, Response>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new();

    void PostToWebApi<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders);

    Response PostToWebApi<Response>(
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new();

    Task<HttpResponseMessage> PostToWebApiAsync<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders);

    Task<HttpResponseMessage> PostToWebApiAsync<Request>(Request request,
      string url,
      [Optional] Dictionary<string, string> customHeaders);

    Response PutToWebApi<Request, Response>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new();

    void PutToWebApi<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders);

    Task<HttpResponseMessage> PutToWebApiAsync<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders);

    Response GetFromWebApi<Response>(string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, object> parameters,
      [Optional]Dictionary<string, string> customHeaders) where Response : new();

    Task<HttpResponseMessage> GetFromWebApiAsync(string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, object> parameters,
      [Optional]Dictionary<string, string> customHeaders);
  }
}
