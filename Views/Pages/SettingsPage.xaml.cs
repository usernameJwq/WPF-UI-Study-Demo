using Wpf.Ui.Controls;

namespace WPF.UI.Study.Views.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<ViewMode.SettingsPageViewModel>
    {
        public ViewMode.SettingsPageViewModel ViewModel { get; }

        public SettingsPage(ViewMode.SettingsPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
