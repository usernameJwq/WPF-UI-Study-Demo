using Wpf.Ui.Controls;

namespace WPF.UI.Study.Views.Pages
{
    /// <summary>
    /// Interaction logic for NAudioRecordPage.xaml
    /// </summary>
    public partial class NAudioRecordPage : INavigableView<ViewMode.NAudioRecordViewModel>
    {
        public ViewMode.NAudioRecordViewModel ViewModel { get; }

        public NAudioRecordPage(ViewMode.NAudioRecordViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
