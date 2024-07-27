using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using MyApp.Contracts.Services;
using MyApp.ViewModels;
using MyApp.Views;
using WpfChart;

namespace MyApp.Services
{   /// <summary>
/// 页服务
/// </summary>
    public class PageService : IPageService
    {
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// 注册页 ,用于导航使用
        /// </summary>
        /// <param name="serviceProvider"></param>
        public PageService(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            Configure<主页ViewModel, 主页>();
            Configure<SettingsViewModel, SettingsPage>();
        
           
            Configure<矿机列表ViewModel         , 矿机列表页>();
            Configure<钱包模板列表页ViewModel, 钱包模板列表页>();
            Configure<超频模板列表页ViewModel, 超频模板列表页>();
            Configure<挖矿模板列表页ViewModel, 挖矿模板列表页>();
            Configure<新增挖矿模板ViewModel   , 新增挖矿模板>();
            Configure<新增超频模板ViewModel   , 新增超频模板页>();
            Configure<矿机详细信息ViewModel   , 矿机详细信息页>();
            Configure<新增钱包模板ViewModel   , 新增钱包模板页>();
            
            Configure<矿机设置ViewModel, 矿机设置页>();
        }

        public Type GetPageType(string key)
        {
            Type pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        public Page GetPage(string key)
        {
            var pageType = GetPageType(key);
          
            return _serviceProvider.GetService(pageType) as Page;
        }

        private void Configure<VM, V>()
            where VM : ObservableObject
            where V : Page
        {
            lock (_pages)
            {
                var key = typeof(VM).FullName;
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (_pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }

                _pages.Add(key, type);
            }
        }
    }
}
