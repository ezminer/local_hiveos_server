namespace MyApp.Contracts.ViewModels
 {
        /// <summary>
        ///  提供导航的接口
        /// </summary>
    public interface INavigationAware
    {
        /// <summary>
        /// 导航到页面
        /// </summary>
        /// <param name="parameter"></param>
        void OnNavigatedTo(object parameter);

        void OnNavigatedFrom();
    }
}
