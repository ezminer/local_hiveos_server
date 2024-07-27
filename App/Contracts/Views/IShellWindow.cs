using System.Windows.Controls;
using MyApp.Contracts.Services;

namespace MyApp.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();
        void ShowMessage(string title, string message);
        void ShowWindow();
        void CloseWindow();
   
        /// <summary>
        /// 在创建完Ishell对象后 赋值导航服务给对象;
        /// </summary>
        INavigationService NavigationService { get; }
     
        void StartLoad();
        void StopLoad();
    }
}
