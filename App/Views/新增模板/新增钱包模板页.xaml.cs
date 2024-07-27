using System.Windows.Controls;

using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 新增钱包模板页 : Page
    {
        public 新增钱包模板页(新增钱包模板ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
