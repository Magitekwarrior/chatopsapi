﻿using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.Http.Headers;
using chatopsapi.Infrastructure.Configurations;

namespace chatopsapi.Infrastructure.HttpClients
{
  /// <summary>
  /// This class will intend is that we can reuse HttpClient instances
  /// </summary>
  public sealed class HttpClientFactory : IHttpClientFactory
  {
		private readonly IConfigService _configService;

    //The instance that will keep all HttpClient instances per baseAddress
    private readonly ConcurrentDictionary<Uri, HttpClient> _httpClients;

    public HttpClientFactory(IConfigService configService)
    {
      _configService = configService;
      _httpClients = new ConcurrentDictionary<Uri, HttpClient>();
    }

    /// <summary>
    /// Returns an instance of HttpClient
    /// </summary>
    /// <param name="baseAddress">the key that will be used to create a new instance of HttpClient</param>
    /// <returns></returns>
    public HttpClient Create(string baseAddress)
    {
      var client = _httpClients.GetOrAdd(new Uri(baseAddress),
          b => new HttpClient { BaseAddress = b });

      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      return client;
    }

    /// <summary>
    /// will create a HttpClient and add Jwt to the header
    /// </summary>
    /// <param name="serviceName">service name in the configuration</param>
    /// <returns></returns>
    public HttpClient CreateWithToken(string serviceName)
    {
      var serviceUrl = _configService.GetServiceEndPoint(serviceName);

      var client = Create(serviceUrl);

      return client;
    }

    public void Dispose()
    {
      foreach (var httpClient in _httpClients.Values)
      {
        httpClient.Dispose();
      }
    }
  }
}
