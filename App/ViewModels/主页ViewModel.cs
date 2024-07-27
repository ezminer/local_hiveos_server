using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using MyApp.Contracts.Views;
using MyApp.Properties;
using MyApp.Views;
using System.Linq;
namespace MyApp.ViewModels
{
    public class 主页ViewModel : ObservableObject
    {
        
        private readonly  IShellWindow _shellWindow;
        public 主页ViewModel(IShellWindow shellWindow )
        {
            _shellWindow=shellWindow;
        }

        public List<IPAddress> IPAddresslist { get; set; } 
      

        /// <summary>
        /// 页面加载完成时
        /// </summary>
        /// <returns></returns>
        public async Task LoadedAsync() {
            
            //获取主机名称
            string name = Dns.GetHostName();
            //获取所有主机地址
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);

            //获取本机所有IPV4地址
            IPAddresslist=ipadrlist.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList();
            //通知UI IPAddresslist已改变
            OnPropertyChanged(nameof(IPAddresslist));
            this.LogINFO("获取本地IP列表成功");            
            //异步完成返回
            await Task.CompletedTask;
        }

    


    }
}
