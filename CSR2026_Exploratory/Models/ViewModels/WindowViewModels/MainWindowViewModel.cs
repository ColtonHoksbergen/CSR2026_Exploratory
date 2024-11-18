using CommunityToolkit.Mvvm.Input;
using CSR2026_Exploratory.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CSR2026_Exploratory.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindowViewModel()
        {
            // Default constructor required to make the XAML happy.
            // The other constructor will be used in runtime.
        }

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        private void PopNewWindow()
        {
            var window = _serviceProvider.GetRequiredService<VehicleFirstNoticeWindow>();
            window.Show();
        }
    }
}
