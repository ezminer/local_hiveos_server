using System;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Controls;

namespace MyApp.Services
{
    /// <summary>
    /// 导航服务
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly IPageService _pageService;
        private Frame _frame;
        private object _lastParameterUsed;

        public event EventHandler<string> Navigated;

        public bool CanGoBack => _frame.CanGoBack;

        public NavigationService(IPageService pageService)
        {
            _pageService = pageService;
        }

        public void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }///下面是后面添加上去的
            else
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }
        /// <summary>
        /// 退订导航
        /// </summary>
        public void UnsubscribeNavigation()
        {
            _frame.Navigated -= OnNavigated;
            _frame = null;
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                var vmBeforeNavigation = _frame.GetDataContext();
                _frame.GoBack();
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }
        }
        /// <summary>
        /// 页面导航  我在里面禁止 导航后腿;
        /// </summary>
        /// <param name="pageKey">页面的viewModel</param>
        /// <param name="parameter">额外参数</param>
        /// <param name="clearNavigation">是否清楚之前的导航</param>
        /// <returns></returns>
        public bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false)
        {
            //获取也的对象类型
            var pageType = _pageService.GetPageType(pageKey);
            /*
             如果页面与当前框架的页面不一致 或    当前参数与上一次参数不相同则 
             */
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                _frame.Tag = clearNavigation;
                var page = _pageService.GetPage(pageKey);
                var navigated = _frame.Navigate(page, parameter);
                //如果导航成功则
                if (navigated)
                {
                   
                    
                    
                    
                    
                    
                    
                    CleanNavigation();
                    //记录当前页面的参数
                    _lastParameterUsed = parameter;
                    var dataContext = _frame.GetDataContext();
                    if (dataContext is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }

                return navigated;
            }

            return false;
        }

        public void CleanNavigation()
            => _frame.CleanNavigation();
        /// <summary>
        /// 进行导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNavigated(object sender, NavigationEventArgs e)
        {

            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.CleanNavigation();
                }

                var dataContext = frame.GetDataContext();
                //如果控件为 可 INavigationAware 的实现类
                if (dataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }

                Navigated?.Invoke(sender, dataContext.GetType().FullName);
            }
        }
    }
}

