using System.Windows.Controls;

using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 矿机设置页 : Page
    {
        public 矿机设置页(矿机设置ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
          //  Loaded+=async (s,e) =>await viewModel
        }
    }
}
