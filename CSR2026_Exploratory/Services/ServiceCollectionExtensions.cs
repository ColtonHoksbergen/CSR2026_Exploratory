using CSR2026_Exploratory.Models;
using CSR2026_Exploratory.ViewModels;
using CSR2026_Exploratory.ViewModels.WindowViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSR2026_Exploratory.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection collection)
        {
            // HTTP Service
            collection.AddSingleton<IHttpContext, HttpContext>();

            // Entity Model Services
            collection.AddSingleton<VehicleFirstNoticeOfLossService>();

            // Windows, Window View models
            collection.AddTransient<MainWindowViewModel>();
            collection.AddTransient<VehicleFirstNoticeWindow>();
            collection.AddTransient<VehicleFirstNoticeWindowViewModel>();

            // Database Context
            collection.AddDbContext<CSRDbContext>(options =>
            options.UseSqlServer("DB CONNECTION STRING"));
        }
    }
}
