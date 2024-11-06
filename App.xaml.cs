using System.IO;
using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WPF.UI.Study.Services;
using Wpf.Ui;
using System.Windows.Threading;
using WPF.UI.Study.Models;

namespace WPF.UI.Study
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly IHost _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c =>
            {
                var basePath =
                    Path.GetDirectoryName(AppContext.BaseDirectory)
                    ?? throw new DirectoryNotFoundException(
                        "Unable to find the base directory of the application."
                    );
                _ = c.SetBasePath(basePath);
            })
            .ConfigureServices((context, services) =>
            {
                // add ApplicationHostService
                _ = services.AddHostedService<ApplicationHostService>();

                // Service containing navigation, same as INavigationWindow... but without window
                _ = services.AddSingleton<INavigationService, NavigationService>();

                // PageService
                _ = services.AddSingleton<IPageService, PageService>();

                // MainWindow and MainWindowViewModel
                _ = services.AddSingleton<INavigationWindow, Views.MainWindow>();
                _ = services.AddSingleton<ViewMode.MainWindowViewModel>();

                // View and ViewModel
                _ = services.AddSingleton<Views.Pages.SettingsPage>();
                _ = services.AddSingleton<ViewMode.SettingsPageViewModel>();
                _ = services.AddSingleton<Views.Pages.DataPage>();
                _ = services.AddSingleton<ViewMode.DataPageViewModel>();
                _ = services.AddSingleton<Views.Pages.DashboardPage>();
                _ = services.AddSingleton<ViewMode.DashboardPageViewModel>();
                _ = services.AddSingleton<Views.Pages.NAudioRecordPage>();
                _ = services.AddSingleton<ViewMode.NAudioRecordViewModel>();

                // Configuration
                _ = services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
            }
            ).Build();

        /// <summary>
        /// Gets services.
        /// </summary>
        public static T GetService<T>()
              where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
