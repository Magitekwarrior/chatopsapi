using System;
using System.Net.Http;

namespace chatopsapi.Infrastructure.HttpClients
{
  public interface IHttpClientFactory : IDisposable
  {
    HttpClient Create(string baseAddress);
    HttpClient CreateWithToken(string serviceName);
  }
}
