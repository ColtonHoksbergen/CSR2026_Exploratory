using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSR2026_Exploratory.Models.ViewModels;
using CSR2026_Exploratory.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CSR2026_Exploratory.ViewModels.WindowViewModels
{
    public partial class VehicleFirstNoticeWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<string> carrierCompanyItems;

        [ObservableProperty]
        public string? carrierCompanyItemSelection;

        [ObservableProperty]
        public ObservableCollection<string> businessUnitItems;

        [ObservableProperty]
        public string? businessUnitItemSelection;

        [ObservableProperty]
        public ObservableCollection<string> adjusterItems;

        [ObservableProperty]
        public string? adjusterItemSelection;

        [ObservableProperty]
        public ObservableCollection<string> programCodeItems;

        [ObservableProperty]
        public string? programCodeSelection;

        [ObservableProperty]
        public ObservableCollection<string> contactMethods;

        [ObservableProperty]
        public ObservableCollection<string> items;

        [ObservableProperty]
        public string? selectedItem;

        [ObservableProperty]
        public string? testString;

        [ObservableProperty]
        public bool testBool;

        public VehicleFirstNoticeViewModel VehicleFirstNoticeViewModel { get; set; } = new VehicleFirstNoticeViewModel();

        private readonly VehicleFirstNoticeOfLossService _vehicleFirstNoticeOfLossService;
        private readonly IServiceProvider _serviceProvider;

        public VehicleFirstNoticeWindowViewModel()
        {
            // Default constructor required to make the XAML happy.
            // The other constructor will be used in runtime.
        }

        public VehicleFirstNoticeWindowViewModel(VehicleFirstNoticeOfLossService vehicleFirstNoticeOfLossService, IServiceProvider serviceProvider)
        {
            _vehicleFirstNoticeOfLossService = vehicleFirstNoticeOfLossService;
            _serviceProvider = serviceProvider;

            //Items = new ObservableCollection<string>()
            //{
            //    "Item 1",
            //    "Item 2",
            //    "Item 3"
            //};

            //CarrierCompanyItems = new ObservableCollection<string>()
            //{
            //    "Company 1",
            //    "Company 2",
            //    "Company 3"
            //};

            //BusinessUnitItems = new ObservableCollection<string>();
            //AdjusterItems = new ObservableCollection<string>();
            //ProgramCodeItems = new ObservableCollection<string>();

            //ContactMethods = new ObservableCollection<string>()
            //{
            //    "Phone",
            //    "Email"
            //};
        }

        [RelayCommand]
        private async Task Submit()
        {
            await _vehicleFirstNoticeOfLossService.TestDBAccessTimings();
        }

        [RelayCommand]
        private void PopNewWindow()
        {
            var window = _serviceProvider.GetRequiredService<VehicleFirstNoticeWindow>();
            window.Show();
        }

        partial void OnCarrierCompanyItemSelectionChanged(string? oldValue, string? newValue)
        {
            VehicleFirstNoticeViewModel.CarrierCompany = newValue;

            // Your logic when selection changes
            BusinessUnitItems.Clear();
            for (int x = 1; x <= 3; x++)
            {
                BusinessUnitItems.Add($"{newValue} Unit {x}");
            }
        }

        partial void OnBusinessUnitItemSelectionChanged(string? oldValue, string? newValue)
        {
            VehicleFirstNoticeViewModel.BusinessUnit = newValue;

            AdjusterItems.Clear();
            for (int x = 1; x <= 3; x++)
            {
                AdjusterItems.Add($"{newValue} Adjuster {x}");
            }
        }

        partial void OnAdjusterItemSelectionChanged(string? oldValue, string? newValue)
        {
            VehicleFirstNoticeViewModel.ProgramCode = newValue;

            ProgramCodeItems.Clear();
            for (int x = 1; x <= 3; x++)
            {
                ProgramCodeItems.Add($"{newValue} Program Code {x}");
            }
        }

        partial void OnProgramCodeSelectionChanged(string? oldValue, string? newValue)
        {
            VehicleFirstNoticeViewModel.ProgramCode = newValue;
        }
    }
}
