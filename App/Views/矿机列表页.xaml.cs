using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Model;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.Models;
using MyApp.ViewModels;


namespace MyApp.Views
{

    public partial class 矿机列表页 : Page
    {
        private readonly IShellWindow _ShellWindow;
        public 矿机列表页(矿机列表ViewModel viewModel, IShellWindow shellWindow)
        {
            DataContext = viewModel;
            InitializeComponent();
            _ShellWindow=shellWindow;
             Loaded += 矿机列表页_Loaded;
            Unloaded += 矿机列表页_Unloaded;
            Config.Default.新增矿机事件 += Default_新增矿机事件; ;
            System.Console.WriteLine($"{DateTime.Now}：{this}:{this.GetHashCode()}被创建了");
        }

        private void Default_新增矿机事件(object sender, EventArgs e)
        {
           
                this.Dispatcher.Invoke(async () => {
                if (DataContext is 矿机列表ViewModel vm)
                {

                    if (vm.验证查询命令())
                    {
                            await Task.Delay(1000);
                        vm.查询内容 = "";
                         vm.查询命令动作();


                        }


                    }
                });


           
        }

        private void 矿机列表页_Unloaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is 矿机列表ViewModel viewModel)
            {
                //viewModel.开始加载 -= ViewModel_开始加载;
                //viewModel.结束加载 -= ViewModel_结束加载;
                
            }
        }
        private async void 矿机列表页_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is 矿机列表ViewModel viewModel)
            {
              
                await  viewModel.LoadAsync();
            }
          
        }
        private void ViewModel_结束加载(object sender, EventArgs e) => _ShellWindow.StopLoad();
        private void ViewModel_开始加载(object sender, EventArgs e) => _ShellWindow.StartLoad();
        ~矿机列表页()
        {
            System.Console.WriteLine($"{DateTime.Now}：{this}:{this.GetHashCode()}被释放了");
        }
      






        #region 选择框改变 用于判断 能否 发送命令
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (DataContext is 矿机列表ViewModel viewModel)
            {


                viewModel.批量命令.NotifyCanExecuteChanged();

                viewModel.批量删除命令.NotifyCanExecuteChanged();
                viewModel.空命令.NotifyCanExecuteChanged();
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataContext is 矿机列表ViewModel viewModel)
            {


                viewModel.批量命令.NotifyCanExecuteChanged();
                viewModel.批量删除命令.NotifyCanExecuteChanged();
                viewModel.空命令.NotifyCanExecuteChanged();
            }
        }
        #endregion

        #region 条目双击事件,用于触发查看状态命令
        private void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is 矿机列表ViewModel viewModel)
            {
                ;
                if (viewModel.选中条目 != null && viewModel.查看状态命令.CanExecute(null))
                {
                    viewModel.查看状态命令.Execute(null);
                }
            }
        } 
        #endregion

        #region 自定义命令打开与关闭
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCMDCode.Visibility == Visibility.Visible)
            {
                CustomCMDCode.Visibility = Visibility.Collapsed;
            }
            else
            {
                CustomCMDCode.Visibility = Visibility.Visible;

            }
        }
        #endregion

        #region 模板打开与关闭
        private void 模板Button_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button)
            {
                if (button.Tag.ToString()=="0")
                {
                    _Wktemplate.Visibility = Visibility.Visible;
                }
                if (button.Tag.ToString() == "1")
                {
                    _Cptemplate.Visibility = Visibility.Visible;
                }
            }

          
        }
        private void 模板取消Button_Click(object sender, RoutedEventArgs e)
        {
             _Wktemplate.Visibility = Visibility.Collapsed;
            _Cptemplate.Visibility = Visibility.Collapsed;
        } 
        #endregion

    }
}





