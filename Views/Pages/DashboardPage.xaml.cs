using Wpf.Ui.Controls;

namespace WPF.UI.Study.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewMode.DashboardPageViewModel>
    {
        public ViewMode.DashboardPageViewModel ViewModel { get; }

        public DashboardPage(ViewMode.DashboardPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
