using CSR2026_Exploratory.Models;
using CSR2026_Exploratory.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CSR2026_Exploratory.Services
{
    public class VehicleFirstNoticeOfLossService
    {
        private readonly IHttpContext _httpContext;
        private readonly CSRDbContext _dbContext;

        public VehicleFirstNoticeOfLossService(IHttpContext httpContext, CSRDbContext dbContext)
        {
            _httpContext = httpContext;
            _dbContext = dbContext;
        }

        public async Task TestDBAccessTimings()
        {
            Stopwatch api = Stopwatch.StartNew();
            // GENERIC API POLL
            api.Stop();

            Stopwatch direct = Stopwatch.StartNew();
            // GENERIC DIRECT DATABASE POLL
            direct.Stop();
        }
    }
}
