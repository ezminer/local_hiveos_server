using System.Windows.Controls;
using MyApp.Contracts.Services;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class 新增挖矿模板 : Page
    {
        public 新增挖矿模板(新增挖矿模板ViewModel viewModel)
        {
            DataContext = viewModel;
            this.viewModel = viewModel;
            InitializeComponent();
            this.Loaded += 新增挖矿模板_Loaded;
       
        }
        新增挖矿模板ViewModel viewModel;
        private void 新增挖矿模板_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            消息管理器.Get消息圈(消息圈.导航到设备详细页).发布消息();
            viewModel.LoadAsync();
        }

        private void 币种列表_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            核心下载地址列表.SelectedIndex = 0;
        }

        private void 核心下载地址列表_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            矿池列表.SelectedIndex = 0;
        }
    }
}
