using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace chatopsapi.Infrastructure.HttpClients
{
	public class HttpClientRepo : IHttpClientRepo
  {
    private IHttpClientFactory _httpClientFactory;

    public HttpClientRepo(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public void PostToWebApi<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = httpClient.PostAsync(requestUri, content).Result;
      response.EnsureSuccessStatusCode();
    }

    public Response PostToWebApi<Request, Response>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new()
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = httpClient.PostAsync(requestUri, content).Result;

      var result = HttpClientReponse<Response>.ReadMessage(response);
      return result;
    }

    public Response PostToWebApi<Response>(
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new()
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var content = new StringContent("", Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = httpClient.PostAsync(requestUri, content).Result;

      var result = HttpClientReponse<Response>.ReadMessage(response);
      return result;
    }

    public async Task<HttpResponseMessage> PostToWebApiAsync<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = await httpClient.PostAsync(requestUri, content);

      return response;
    }

    public async Task<HttpResponseMessage> PostToWebApiAsync<Request>(Request request,
      string url,
      [Optional] Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.Create(url);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri;

      var response = await httpClient.PostAsync(serviceUrl, content);

      return response;
    }

    public Response PutToWebApi<Request, Response>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders) where Response : new()
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = httpClient.PutAsync(requestUri, content).Result;

      var result = HttpClientReponse<Response>.ReadMessage(response);
      return result;
    }

    public async Task<HttpResponseMessage> PutToWebApiAsync<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = await httpClient.PutAsync(requestUri, content);

      return response;
    }

    public void PutToWebApi<Request>(Request request,
      string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var req = JsonConvert.SerializeObject(request);
      var content = new StringContent(req, Encoding.UTF8, "application/json");

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;
      string requestUri = GetRequestUri(serviceUrl, action, controller);

      var response = httpClient.PutAsync(requestUri, content).Result;
      response.EnsureSuccessStatusCode();
    }

    public Response GetFromWebApi<Response>(string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, object> parameters,
      [Optional]Dictionary<string, string> customHeaders
      ) where Response : new()
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;

      string requestUri = string.Empty;
      if (parameters != null)
      {
        requestUri = GetRequestUri(serviceUrl, action, controller, parameters);
      }
      else
      {
        requestUri = GetRequestUri(serviceUrl, action, controller);
      }

      var response = httpClient.GetAsync(requestUri).Result;

      var result = HttpClientReponse<Response>.ReadMessage(response);
      return result;
    }

    public async Task<HttpResponseMessage> GetFromWebApiAsync(string serviceName,
      string version,
      string action,
      string controller,
      [Optional]Dictionary<string, object> parameters,
      [Optional]Dictionary<string, string> customHeaders)
    {
      var httpClient = _httpClientFactory.CreateWithToken(serviceName);

      AddCustomerHeaders(customHeaders, httpClient);

      var serviceUrl = httpClient.BaseAddress.AbsoluteUri + version;

      string requestUri = string.Empty;
      if (parameters != null)
      {
        requestUri = GetRequestUri(serviceUrl, action, controller, parameters);
      }
      else
      {
        requestUri = GetRequestUri(serviceUrl, action, controller);
      }

      var response = await httpClient.GetAsync(requestUri);

      return response;
    }

    private static string GetRequestUri(string serviceUrl,
      string action,
      string controller,
      [Optional]Dictionary<string, object> parameters)
    {
      string baseUri;

      if (string.IsNullOrEmpty(action) && string.IsNullOrEmpty(controller))
      {
        baseUri = string.Format("{0}", serviceUrl);
      }
      else
      {
        baseUri = string.Format("{0}/{1}/{2}",
                                    serviceUrl,
                                    controller,
                                    action);
      }

      var requestUri = string.Format("{0}", baseUri);
      if (parameters != null)
      {
        requestUri = string.Format("{0}?", requestUri);
        foreach (var param in parameters)
        {
          var value = (param.Value != null) ? param.Value.ToString() : "null";

          requestUri = QueryHelpers.AddQueryString(requestUri, param.Key, value);
        }
      }

      return requestUri;
    }

    private static void AddCustomerHeaders(Dictionary<string, string> customHeaders,
      HttpClient httpClient)
    {
      if (customHeaders != null)
      {
        foreach (var header in customHeaders)
        {
          if (!httpClient.DefaultRequestHeaders.Contains(header.Key))
          {
            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
          }
        }
      }
    }
  }
}
