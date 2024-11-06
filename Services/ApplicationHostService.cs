using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;
using WPF.UI.Study.Views;

namespace WPF.UI.Study.Services
{
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private INavigationWindow _navigationWindow;

        public ApplicationHostService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivationAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            await Task.CompletedTask;

            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (
                    _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow
                )!;
                _navigationWindow!.ShowWindow();

                // 启动程序，界面默认跳转首页
                var page = Type.GetType("WPF.UI.Study.Views.Pages.DashboardPage");
                _ = _navigationWindow.Navigate(page);
            }

            await Task.CompletedTask;
        }
    }
}
