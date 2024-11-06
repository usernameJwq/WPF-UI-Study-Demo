using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui;
using Wpf.Ui.Controls;
using WPF.UI.Study.Views.Pages;

namespace WPF.UI.Study.ViewMode
{
    public class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        // App Title
        private string _applicationTitle;
        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => SetProperty(ref _applicationTitle, value);
        }

        private ObservableCollection<object> _navigationItems;
        public ObservableCollection<object> NavigationItems
        {
            get => _navigationItems;
            set => SetProperty(ref _navigationItems, value);
        }

        private ObservableCollection<object> _navigationFooter;
        public ObservableCollection<object> NavigationFooter
        {
            get => _navigationFooter;
            set => SetProperty(ref _navigationFooter, value);
        }

        private ObservableCollection<MenuItem> _trayMenuItems;
        public ObservableCollection<MenuItem> TrayMenuItems
        {
            get => _trayMenuItems;
            set => SetProperty(ref _trayMenuItems, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Style",
            "IDE0060:Remove unused parameter",
            Justification = "Demo"
        )]
        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "WPF UI Demo";

            NavigationItems = new ObservableCollection<object>
            {
                new NavigationViewItem()
                {
                    Content = "Home",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                    TargetPageType = typeof(DashboardPage)
                },
                new NavigationViewItem()
                {
                    Content = "AudioRecord",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Mic24 },
                    TargetPageType = typeof(NAudioRecordPage)
                },
                new NavigationViewItem()
                {
                    Content = "Data",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                    TargetPageType = typeof(DataPage)
                }
            };

            NavigationFooter = new ObservableCollection<object>
            {
                new NavigationViewItem()
                {
                    Content = "Settings",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                    TargetPageType = typeof(SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem() { Header = "Home", Tag = "Tray_Home" }
            };

            _isInitialized = true;
        }
    }
}
