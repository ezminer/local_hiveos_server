using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.Controls;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {

        private IServiceProvider _serviceProvider;
        public ShellWindow(ShellViewModel viewModel,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = viewModel;
            _serviceProvider = serviceProvider;   
            this.Loaded += 窗体加载完成时;

        }
        private  Timer Timer;

        INavigationService IShellWindow.NavigationService { get => _serviceProvider.GetService(typeof(INavigationService)) as INavigationService; }

        //  CustomDialog d;
        private  void 窗体加载完成时(object sender, System.Windows.RoutedEventArgs e)
        {

            消息管理器.Get消息圈(消息圈.导航到设备详细页).消息提醒 += ShellWindow_消息提醒; ;
            //创建一个定时器//时间间隔1000毫秒
            Timer = new Timer() { Interval=1000};
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();

         
        }

        private void ShellWindow_消息提醒(object message)
        {
            //菜单栏跳转到-1,防止导航到设备详细页 索引还在 设备列表中
            hamburgerMenu.SelectedIndex = -1;
        }

        

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_Message.Items.Count > 0)
            {
                var _基本消息 = _Message.Items[0] as 基本消息;
                if (Math.Abs((DateTime.Now - _基本消息.创建时间).Seconds) > 3)
                {
                    Dispatcher.Invoke(() => { _Message.Items.RemoveAt(0); });

                }
            }
        
        }

        public  void StartLoad() {

            Loading.Visibility = Visibility.Visible;
          
        }
        public void StopLoad() { Loading.Visibility = Visibility.Collapsed;}

        public Frame GetNavigationFrame()=> shellFrame;

        public void ShowWindow()=> Show();

        public void CloseWindow()=> Close();


        private void 启用置顶(object sender, RoutedEventArgs e) => this.Topmost = true;
        private void 取消置顶(object sender, RoutedEventArgs e) => this.Topmost = false;


        public void ShowMessage(string title, string message) => _Message.Items.Add(new 基本消息(title, message));
   
    }
}