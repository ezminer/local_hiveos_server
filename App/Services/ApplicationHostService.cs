using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;

using MyApp.Contracts.Activation;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.ViewModels;

namespace MyApp.Services
{
    /// <summary>
    /// 程序基本服务
    /// </summary>
    public class ApplicationHostService : IHostedService
    {
        /// <summary>
        /// ioc服务
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// 导航服务
        /// </summary>
        private readonly INavigationService _navigationService;
       /// <summary>
       /// 主题服务
       /// </summary>
        private readonly IThemeSelectorService _themeSelectorService;
        /// <summary>
        /// 存储服务
        /// </summary>
        private readonly IPersistAndRestoreService _persistAndRestoreService;
        private readonly IEnumerable<IActivationHandler> _activationHandlers;
        /// <summary>
        /// 导航窗体
        /// </summary>
        private IShellWindow _shellWindow;
        private bool _isInitialized;
        /// <summary>
        /// 构造函数 依赖注入
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="activationHandlers"></param>
        /// <param name="navigationService"></param>
        /// <param name="persistAndRestoreService"></param>
        /// <param name="themeSelectorService"></param>
        public ApplicationHostService(IServiceProvider serviceProvider, IEnumerable<IActivationHandler> activationHandlers, INavigationService navigationService, IPersistAndRestoreService persistAndRestoreService, IThemeSelectorService themeSelectorService)
        {
            _serviceProvider = serviceProvider;
            _activationHandlers = activationHandlers;
            _navigationService = navigationService;
            _persistAndRestoreService = persistAndRestoreService;
            _themeSelectorService = themeSelectorService;
          
        }
        /// <summary>
        /// 启动程序可取消
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
            _isInitialized = true;
        }
        /// <summary>
        /// 停止程序
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _persistAndRestoreService.PersistData();
            await Task.CompletedTask;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                _persistAndRestoreService.RestoreData();
                _themeSelectorService.InitializeTheme();
                await Task.CompletedTask;
            }
        }
        /// <summary>
        /// 启动程序
        /// </summary>
        /// <returns></returns>
         private async Task StartupAsync()
            {
                await Task.CompletedTask;
            }
        /// <summary>
        /// 激活窗体
        /// </summary>
        /// <returns></returns>
        private async Task HandleActivationAsync()
        {
            var activationHandler = _activationHandlers.FirstOrDefault(h => h.CanHandle());

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync();
            }

          
         
            if (App.Current.Windows.OfType<IShellWindow>().Count() == 0)
            {
               //从ioc容器获取窗体
                _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
                Application.Current.MainWindow = _shellWindow as Window;
                //初始化导航服务
                _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                //显示窗体
                _shellWindow.ShowWindow();
                //导航到主页
                _navigationService.NavigateTo(typeof(主页ViewModel).FullName);

               
                _serviceProvider.GetService(typeof(ITimerTaskService));
                await Task.CompletedTask;
            }
        }
    }
}
