using Avalonia.Controls;
using CSR2026_Exploratory.ViewModels.WindowViewModels;

namespace CSR2026_Exploratory;

public partial class VehicleFirstNoticeWindow : Window
{
    public VehicleFirstNoticeWindow()
    {
        // XAML components must have a parameterless constructor, even if it is not used.
        DataContext = new VehicleFirstNoticeWindowViewModel(); // Use design-time or mock data
        InitializeComponent();
    }

    public VehicleFirstNoticeWindow(VehicleFirstNoticeWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}