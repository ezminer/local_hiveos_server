using System.Windows.Controls;
using MahApps.Metro.Controls;
using Model;
using MyApp.Properties;
using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            
        }

    }
}
