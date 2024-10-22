using Wpf.Ui.Controls;

namespace WPF.UI.Study.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : INavigableView<ViewMode.DataPageViewModel>
    {
        public ViewMode.DataPageViewModel ViewModel { get; }

        public DataPage(ViewMode.DataPageViewModel viewMode)
        {
            ViewModel = viewMode;
            DataContext = this;

            InitializeComponent();
        }
    }
}
