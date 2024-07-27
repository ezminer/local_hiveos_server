using System;
using System.Collections.Generic;
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
using MyApp.Contracts.Services;
using MyApp.Controls;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Views
{
    /// <summary>
    /// QBListPage.xaml 的交互逻辑
    /// </summary>
    public partial class 钱包模板列表页 : Page
    {
        
        public 钱包模板列表页(钱包模板列表页ViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();

            Loaded+=async (s,e)=> await viewModel.LoadcmdAysnc();
          
        }

        ~钱包模板列表页()
        {
            System.Console.WriteLine($"{DateTime.Now}：{this}被释放了");
        }


        private void SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataContext is 钱包模板列表页ViewModel d)
            {
                d.删除命令.NotifyCanExecuteChanged();
            }
        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is 钱包模板列表页ViewModel d)
            {
                d.修改命令.Execute(null);
            }
        }
    }
}
