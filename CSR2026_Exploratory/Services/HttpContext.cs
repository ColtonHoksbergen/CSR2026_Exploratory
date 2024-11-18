using System;
using System.Net.Http;

namespace CSR2026_Exploratory.Services
{
    internal class HttpContext : IHttpContext
    {
        public HttpClient HttpClient { get; } = new HttpClient();

        public Uri? BaseAddress
        {
            get => HttpClient.BaseAddress;
            set => HttpClient.BaseAddress = value;
        }

        public HttpContext()
        {
            // Optionally configure the HttpClient
            //HttpClient.BaseAddress = new Uri("API URI STRING");
            HttpClient.Timeout = TimeSpan.FromSeconds(30);
        }
    }
}
