using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Toolkit.Uwp.Notifications;
using MyWebApplication;


using MyApp.Activation;
using MyApp.Contracts.Activation;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.Core.Contracts.Services;
using MyApp.Core.Services;
using MyApp.Models;
using MyApp.Services;
using MyApp.ViewModels;
using MyApp.Views;
using MyApp.DialogView;
using Microsoft.AspNetCore.Hosting;
using MyWebApplication.IService;

namespace MyApp
{
    
    public partial class App : Application
    {
        private IHost _host;

        public T GetService<T>()where T : class=> _host.Services.GetService(typeof(T)) as T;
        /// <summary>
        /// 改对象的静态实例静态实例
        /// </summary>
        public static App app =new App();
        private App()
        {
            //注册编码防止 gb2312乱码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
        }
        //web服务线程
        private Thread WebThread;


        public static void Close() {
            app.Shutdown();        
        }
       
        private async void OnStartup(object sender, StartupEventArgs e)
        {
          
             var activationArgs = new Dictionary<string, string>
            {
                { ToastNotificationActivationHandler.ActivationArguments, string.Empty }
            };
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


           
           
            System.Uri uri =new System.Uri(Model.Config.Default.SERVERIP);
           
            _host = Host.CreateDefaultBuilder(e.Args)
                    .ConfigureAppConfiguration(c =>
                    {
                        c.SetBasePath(appLocation);
                        c.AddInMemoryCollection(activationArgs);
                    })         
                     .ConfigureWebHostDefaults(webBuilder =>
                    {

                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseKestrel();
                        webBuilder.UseUrls("http://*:" + uri.Port);
                       // webBuilder.UseUrls(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "服务器地址.txt"));
                    }).ConfigureServices(ConfigureServices)
                    .Build();


            

            //WebThread = new Thread(_host.Run);
            //WebThread.IsBackground = true;
            //WebThread.Start();

           var SQLQueue = (_host.Services.GetService(typeof(ISQLQueueService)) as ISQLQueueService);
            SQLQueue.RunSQLQueueService();
            await _host.StartAsync();
        }
        /// <summary>
        /// IOC容器注册一些服务
        /// </summary>
        /// <param name="context"></param>
        /// <param name="services"></param>
        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // TODO WTS: Register your services, viewmodels and pages here

            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Activation Handlers
            services.AddSingleton<IActivationHandler, ToastNotificationActivationHandler>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();


            services.AddSqlsugarSetup(null);

        
            // Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
            services.AddSingleton<ISystemService, SystemService>();
            services.AddSingleton<IMyLog, MyLog>();
            

            //定时任务服务
            services.AddSingleton<ITimerTaskService, TimerTaskService>();

            
            services.AddSingleton<IWindowManagerService, WindowManagerService>();
         



            //  services.AddSingleton<IToastNotificationsService, ToastNotificationsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();


            // Views and ViewModels
            services.AddSingleton<IShellWindow, ShellWindow>();
            services.AddSingleton<ShellViewModel>();

            //services.AddSingleton<Window1>();
            //services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<IShellDialogWindow, ShellDialogWindow>();
            services.AddTransient<ShellDialogViewModel>();
            services.AddTransient<CustomCMDDialogView>();
            services.AddTransient<CustomCMDDialogViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();

            services.AddTransient<主页ViewModel>();
            services.AddTransient<主页>();

            services.AddTransient<矿机列表ViewModel>();
            services.AddTransient<矿机列表页>();

            services.AddTransient<钱包模板列表页ViewModel>();
            services.AddTransient<钱包模板列表页>();

            services.AddTransient<超频模板列表页ViewModel>();
            services.AddTransient<超频模板列表页>();

            services.AddTransient<挖矿模板列表页ViewModel>();
            services.AddTransient<挖矿模板列表页>();

            services.AddTransient<新增挖矿模板ViewModel>();
            services.AddTransient<新增挖矿模板>();

            services.AddTransient<新增超频模板ViewModel>();
            services.AddTransient<新增超频模板页>();

            services.AddTransient<矿机详细信息ViewModel>();
            services.AddTransient<矿机详细信息页>();

            services.AddTransient<新增钱包模板ViewModel>();
            services.AddTransient<新增钱包模板页>();

            services.AddTransient<矿机设置ViewModel>();
            services.AddTransient<矿机设置页>();

            // Configuration
            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            
            await _host.StopAsync();
           // WebThread.Abort();
            
            _host.Dispose();
            _host = null;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

            this.LogException(e.Exception);
          }
    }
}
