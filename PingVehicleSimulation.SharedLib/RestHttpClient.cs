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
	    public static HttpClient GetHttpClientInstance(string uri)
	    {
		    var httpClient = new HttpClient { BaseAddress = new Uri(uri) };

		    httpClient.DefaultRequestHeaders.Accept.Clear();
		    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		    return httpClient;
	    }
    }
}
