using System;
using System.Windows.Controls;

using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 超频模板列表页 : Page
    {
        public 超频模板列表页(超频模板列表页ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            this.Loaded +=  (s, e) => viewModel.Loadcmdasync();
        }
        ~超频模板列表页()
        {
            System.Console.WriteLine($"{DateTime.Now}：{this}被释放了");
        }
        private void SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataContext is 超频模板列表页ViewModel d)
            {
                d.删除命令.NotifyCanExecuteChanged();
            }
        }

      
    }
}
