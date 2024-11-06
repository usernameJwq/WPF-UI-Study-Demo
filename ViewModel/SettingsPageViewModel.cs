using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Appearance;

namespace WPF.UI.Study.ViewMode
{
    public partial class SettingsPageViewModel : ObservableObject
    {
        private string _appVersion;
        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }

        private ApplicationTheme _curApplicationTheme = ApplicationTheme.Light;
        public ApplicationTheme CurApplicationTheme
        {
            get => _curApplicationTheme;
            set
            {
                if (SetProperty(ref _curApplicationTheme, value))
                {
                    ChangeApplicationTheme(_curApplicationTheme);
                }
            }
        }

        private void ChangeApplicationTheme(ApplicationTheme curApplicationTheme)
        {
            ApplicationThemeManager.Apply(curApplicationTheme);
        }
    }
}
