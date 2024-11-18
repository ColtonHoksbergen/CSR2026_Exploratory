using CommunityToolkit.Mvvm.ComponentModel;
using CSR2026_Exploratory.Models.ViewModels;
using System;

namespace CSR2026_Exploratory.ViewModels
{
    public partial class VehicleFirstNoticeViewModel : ViewModelBase
    {
        public VehicleFirstNoticeViewModel()
        {
        }


        public string? CarrierCompany { get; set; }

        public string? BusinessUnit { get; set; }

        public string? ProgramCode { get; set; }

        [ObservableProperty]
        public string? contactFirstName;

        [ObservableProperty]
        public string? contactLastName;

        [ObservableProperty]
        public string? contactPhone;

        [ObservableProperty]
        public string? contactEmail;

        [ObservableProperty]
        public string? preferredContactMethod;

        [ObservableProperty]
        public TimeSpan? preferredContactTime;
    }
}
