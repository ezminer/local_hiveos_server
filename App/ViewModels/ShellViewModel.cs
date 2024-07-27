using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using MyApp.Contracts.Services;
using MyApp.Properties;
using MyApp.Services;
using MyApp.Views;

namespace MyApp.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        private readonly IWindowManagerService _windowManagerService;
       
        private readonly INavigationService _navigationService;
        private HamburgerMenuItem _selectedMenuItem;
        private HamburgerMenuItem _selectedOptionsMenuItem;
        private RelayCommand _goBackCommand;
        private ICommand _menuItemInvokedCommand;
        private ICommand _optionsMenuItemInvokedCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;
        private FontFamily fontFamily = new FontFamily(AppDomain.CurrentDomain.BaseDirectory + "Assets\\#iconfont");
        public HamburgerMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { SetProperty(ref _selectedMenuItem, value); }
        }

        public HamburgerMenuItem SelectedOptionsMenuItem
        {
            get { return _selectedOptionsMenuItem; }
            set { SetProperty(ref _selectedOptionsMenuItem, value); }
        }

        // TODO WTS: Change the icons and titles for all HamburgerMenuItems here.
        public ObservableCollection<HamburgerMenuItem> MenuItems { get; } = new ObservableCollection<HamburgerMenuItem>()
        {
            new HamburgerMenuGlyphItem() {  Label = Resources.ShellMainPage, Glyph = "\ue7bd", TargetPageType = typeof(主页ViewModel) },
            new HamburgerMenuGlyphItem() { Label = Resources.ShellKJManagePage, Glyph = "\ue7bd", TargetPageType = typeof(矿机列表ViewModel) },
           // new HamburgerMenuGlyphItem() { Label = Resources.ShellQBListPage, Glyph = "\uE8A5", TargetPageType = typeof(钱包模板列表页ViewModel) },
            new HamburgerMenuGlyphItem() { Label = Resources.ShellCPTemplatePage, Glyph = "\uE8A5", TargetPageType = typeof(超频模板列表页ViewModel) },
            new HamburgerMenuGlyphItem() { Label = Resources.ShellWKTemplatePage, Glyph = "\uE8A5", TargetPageType = typeof(挖矿模板列表页ViewModel) },
         //   new HamburgerMenuGlyphItem() { Label = Resources.ShellAddWKTemplatePage, Glyph = "\uE8A5", TargetPageType = typeof(新增挖矿模板ViewModel) },
         //   new HamburgerMenuGlyphItem() { Label = Resources.ShellAddCPTemplatePage, Glyph = "\uE8A5", TargetPageType = typeof(新增超频模板ViewModel) },
            //new HamburgerMenuGlyphItem() { Label = Resources.Shell矿机详细信息Page, Glyph = "\uE8A5", TargetPageType = typeof(矿机详细信息ViewModel) },
           // new HamburgerMenuGlyphItem() { Label = Resources.Shell新增钱包模板页Page, Glyph = "\uE8A5", TargetPageType = typeof(新增钱包模板ViewModel) },
           // new HamburgerMenuGlyphItem() { Label = Resources.ShellBlankPage, Glyph = "\uE8A5", TargetPageType = typeof(矿机设置ViewModel) },
        };

        public ObservableCollection<HamburgerMenuItem> OptionMenuItems { get; } = new ObservableCollection<HamburgerMenuItem>()
        {
            new HamburgerMenuGlyphItem() { Label = Resources.ShellSettingsPage, Glyph = "\uE713", TargetPageType = typeof(SettingsViewModel) }
        };

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand MenuItemInvokedCommand => _menuItemInvokedCommand ?? (_menuItemInvokedCommand = new RelayCommand(OnMenuItemInvoked));

        public ICommand OptionsMenuItemInvokedCommand => _optionsMenuItemInvokedCommand ?? (_optionsMenuItemInvokedCommand = new RelayCommand(OnOptionsMenuItemInvoked));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ShellViewModel(INavigationService navigationService,
          
            IWindowManagerService windowManagerService)
        {
            _navigationService = navigationService;
            _windowManagerService = windowManagerService;
           
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private async void OnMenuItemInvoked()
        {

           
        
            await Task.Delay(100);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //程序开始

            NavigateTo(SelectedMenuItem.TargetPageType);

            _navigationService.CleanNavigation();

            sw.Stop();

        

        }

        private void OnOptionsMenuItemInvoked()
            => NavigateTo(SelectedOptionsMenuItem.TargetPageType);

        private  void NavigateTo(Type targetViewModel)
        {
            if (targetViewModel != null)
            {
                _navigationService.NavigateTo(targetViewModel.FullName,clearNavigation: true);
                _navigationService.CleanNavigation();
            }
        }

        private void OnNavigated(object sender, string viewModelName)
        {
            var item = MenuItems
                        .OfType<HamburgerMenuItem>()
                        .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);
            if (item != null)
            {
                SelectedMenuItem = item;
            }
            else
            {
                SelectedOptionsMenuItem = OptionMenuItems
                        .OfType<HamburgerMenuItem>()
                        .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);
            }

            GoBackCommand.NotifyCanExecuteChanged();
        }
    }
}
