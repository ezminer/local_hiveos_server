using System.Windows.Controls;

using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 新增超频模板页 : Page
    {
        public 新增超频模板页(新增超频模板ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
