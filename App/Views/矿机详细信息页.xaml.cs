using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.ViewModels;
using System.Threading.Tasks;

namespace MyApp.Views
{
    public partial class 矿机详细信息页 : Page
    {
       
        public 矿机详细信息页(矿机详细信息ViewModel viewModel)
        {
           
            InitializeComponent();
            DataContext = viewModel;
            this.Loaded += 矿机详细信息页_Loaded;
        }

        private async void 矿机详细信息页_Loaded(object sender, RoutedEventArgs e)
        {
            消息管理器.Get消息圈(消息圈.导航到设备详细页).发布消息();

            await Task.Delay(1200);
            try
            {
                chart.刷新((DataContext as 矿机详细信息ViewModel).Machine_info.rig_id);
            }
            catch (System.Exception)
            {

                MessageBox.Show("加载失败");
            }
        }

        private void DataGrid_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);

            eventArg.RoutedEvent = UIElement.MouseWheelEvent;

            eventArg.Source = sender;

            
            (sender as FrameworkElement).RaiseEvent(eventArg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                chart.刷新((sender as Button).Tag.ToString());
            }
            catch (System.Exception)
            {

              //  MessageBox.Show("加载失败");
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
