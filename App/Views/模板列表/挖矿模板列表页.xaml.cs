using System;
using System.Windows.Controls;

using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 挖矿模板列表页 : Page
    {
        static int i;
        public 挖矿模板列表页(挖矿模板列表页ViewModel viewModel)
        {
           
            DataContext = viewModel;
            InitializeComponent();
            System.Console.WriteLine($"{DateTime.Now}：{this}存活数量{++i}");
            Loaded += async (s,e)=> await viewModel.LoadAsync();
        }
        ~挖矿模板列表页()
        {
            System.Console.WriteLine($"{DateTime.Now}：{this}存活数量{--i}");
        }
        private void SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataContext is 挖矿模板列表页ViewModel d)
            {
                d.删除命令.NotifyCanExecuteChanged();
                d.修改命令.NotifyCanExecuteChanged();
                d.删除命令2.NotifyCanExecuteChanged();
                d.修改命令2.NotifyCanExecuteChanged();
            }
        }


      
    }
}
