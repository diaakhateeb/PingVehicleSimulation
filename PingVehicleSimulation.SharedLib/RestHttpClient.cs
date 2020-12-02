using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PingVehicleSimulation.SharedLib
{
    public enum BackendRestTarget
    {
        V1,
        V2
    }
    public class RestHttpClient
    {
        private static readonly HttpClient _httpClient;
        static RestHttpClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:64195/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient GetHttpClientInstance => _httpClient;
    }
}
