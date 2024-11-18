using System;
using System.Net.Http;

namespace CSR2026_Exploratory.Services
{
    public interface IHttpContext
    {
        HttpClient HttpClient { get; }
        Uri? BaseAddress { get; set; }
    }
}
