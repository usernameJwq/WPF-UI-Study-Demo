using System;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace WPF.UI.Study.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INavigationWindow
    {
        public ViewMode.MainWindowViewModel ViewModel { get; }

        public MainWindow(ViewMode.MainWindowViewModel viewModel,
            ViewMode.SettingsPageViewModel settingsPageViewModel,
            IPageService pageService,
            INavigationService navigationService)
        {
            ViewModel = viewModel;
            DataContext = this;

            SystemThemeWatcher.Watch(this);

            InitializeComponent();

            // 初始化设置背景颜色
            ApplicationThemeManager.Apply(settingsPageViewModel.CurApplicationTheme);

            SetPageService(pageService);
            navigationService.SetNavigationControl(RootNavigation);
        }

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) => RootNavigation.SetPageService(pageService);

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
