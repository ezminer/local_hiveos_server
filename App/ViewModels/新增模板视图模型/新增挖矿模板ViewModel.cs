using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using Newtonsoft.Json;
using SqlSugar;


using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Contracts.Views;
using MyApp.Core.Contracts.Services;

using MyApp.DataRepositories.Model;
using MyApp.Models;
using MyApp.Properties;
using System.Net.Http;

namespace MyApp.ViewModels
{
    public partial class 新增挖矿模板ViewModel : ObservableObject, INavigationAware
    {
        private readonly IShellWindow _shellWindow;
        private readonly SqlSugarScope _db;
        //private 币种Item _币种Item;       
        //private 矿池Item _矿池Item;
        //private 核心下载地址Item _核心下载地址Item;
        private Mining _Mining;
      
        public Mining DefaultMining    { get => _Mining; set => SetProperty(ref _Mining, value); }

        private Mining _CustomMining;

        public Mining CustomMining { get => _CustomMining??(_CustomMining=new Mining()); set => SetProperty(ref _CustomMining, value); }


        public 新增挖矿模板ViewModel(IFileService fileService,IShellWindow shellWindow, SqlSugarScope db)
        {
            _db = db;
            _shellWindow =shellWindow;
            DefaultMining = new();
        }

        //public 币种Item 币种Item { get => _币种Item; set => SetProperty(ref _币种Item, value); }
        //public 核心下载地址Item 核心下载地址Item { get => _核心下载地址Item; set => SetProperty(ref _核心下载地址Item, value); }
        //public 矿池Item 矿池Item { get => _矿池Item; set => SetProperty(ref _矿池Item, value); }

        public void LoadAsync() {

            try
            {
                挖矿模板Json 挖矿模板Json列表 = JsonConvert.DeserializeObject<挖矿模板Json>(Config.Default.WkTemlpate);
                默认模板币种列表= 挖矿模板Json列表.data;
                OnPropertyChanged(nameof(默认模板币种列表));
                OnPropertyChanged(nameof(币种Item)); 
                OnPropertyChanged(nameof(矿池Item)); 
                OnPropertyChanged(nameof(核心下载地址Item));
                
            }
            catch (Exception)
            {

                _shellWindow.ShowMessage("错误","加载模板失败!\n请尝试更新模板");
            }
           
        }

        private RelayCommand _返回命令;
        public RelayCommand 返回命令 => _返回命令 ?? (_返回命令 = new RelayCommand(返回命令动作));
        public void 返回命令动作()
        {
         _shellWindow.NavigationService.NavigateTo(typeof(挖矿模板列表页ViewModel).FullName, clearNavigation: true);
        }


        #region 更新模板信息
        private ICommand _UpdateWkTemplateCmd;
        public ICommand UpdateWkTemplateCmd => _UpdateWkTemplateCmd ?? (_UpdateWkTemplateCmd = new RelayCommand(UpdateWkTemplateCmdAtion));
        private async void UpdateWkTemplateCmdAtion()
        {

            Stream stream = null;
            TextReader reader = null;
            try
            {
                _shellWindow.ShowMessage("提示", "开始下载挖矿模板!");
                HttpClient httpClient = new HttpClient();

                stream = await httpClient.GetStreamAsync(Config.Default.模板下载地址);

                reader = new StreamReader(stream, Encoding.UTF8);
                string data = reader.ReadToEndAsync().Result;
                Config.Default.WkTemlpate = data;
                Config.Default.Save();
                

                _shellWindow.ShowMessage("提示", "挖矿模板更新完成!");
                LoadAsync();

            }
            catch (Exception ex)
            {

                _shellWindow.ShowMessage("错误", "挖矿模板更新失败!");
            }
            finally
            {
                reader?.Dispose();
                stream?.Dispose();

            }

        }


        #endregion

        #region 添加命令
        private RelayCommand _添加命令;
        public RelayCommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand(添加命令动作));


        public async void 添加命令动作()
        {

            //默认模板.CoinName = 币种Item?.币种;
            //默认模板.MinerverName = 核心下载地址Item?.核心名字;
            //默认模板.MinerverAddr= 核心下载地址Item?.下载地址;
            //默认模板.PoolName = 矿池Item?.名字;
            //默认模板.PoolAddr = 矿池Item?.代理;
            // DefaultMining.挖矿软件名称 = 核心?.核心名字;

            DefaultMining.CoinName = 选中币种Item.币种;
            DefaultMining.PoolAddr = 选中币种矿池Item.代理;
            DefaultMining.MinerverAddr= 选中核心下载地址Item.下载地址;
            DefaultMining.MinerverName = 选中核心下载地址Item.核心名字;
            DefaultMining.挖矿软件名称 = 选中核心下载地址Item.核心名字;

            try
            {
                if (_db.Insertable(DefaultMining).ExecuteCommand() > 0)
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "保存成功!");
                    _shellWindow.NavigationService.NavigateTo(typeof(挖矿模板列表页ViewModel).FullName,clearNavigation:true);

                   await Down(DefaultMining.MinerverAddr);
                }
                else
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
            }


        }




        private RelayCommand _添加自定义模板命令;
        public RelayCommand 添加自定义模板命令 => _添加自定义模板命令 ?? (_添加命令 = new RelayCommand(添加自定义模板命令动作));


        public async void 添加自定义模板命令动作()
        {

            //默认模板.CoinName = 币种Item?.币种;
            //默认模板.MinerverName = 核心下载地址Item?.核心名字;
            //默认模板.MinerverAddr= 核心下载地址Item?.下载地址;
            //默认模板.PoolName = 矿池Item?.名字;
            //默认模板.PoolAddr = 矿池Item?.代理;
            // DefaultMining.挖矿软件名称 = 核心?.核心名字;

            //DefaultMining.CoinName = 选中币种Item.币种;
            //DefaultMining.PoolAddr = 选中币种矿池Item.代理;
            //DefaultMining.MinerverAddr = 选中核心下载地址Item.下载地址;
            //DefaultMining.MinerverName = 选中核心下载地址Item.核心名字;
            //DefaultMining.挖矿软件名称 = 选中核心下载地址Item.核心名字;
            if (string.IsNullOrEmpty(CustomMining.MinerverName))
            {
                CustomMining.MiningName = Guid.NewGuid().ToString();

            }
            CustomMining.默认模板 = 1;
            try
            {
                if (_db.Insertable(CustomMining).ExecuteCommand() > 0)
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "保存成功!");
                    _shellWindow.NavigationService.NavigateTo(typeof(挖矿模板列表页ViewModel).FullName, clearNavigation: true);

                    await Down(CustomMining.MinerverAddr);
                }
                else
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ex.LogException(ex);
               // _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
            }


        }



        public  async Task Down(string Url)
        {


        
                Stream stream = null;
                TextReader reader = null;
                try
                {
                if (string.IsNullOrEmpty(Url))
                {
                    return;

                }
                    var arr = Url.Split("/");
                    string FileName = arr[arr.Length - 1];
                    if (File.Exists("./miners/" + FileName))
                    {
                        return;
                    }

                    _shellWindow.ShowMessage("提示", "开始预下载核心!");
                    HttpClient httpClient = new HttpClient();

                stream = await httpClient.GetStreamAsync(Url);
              

                byte[] buff=    await Task.Run(() => {
                             List<byte> bytelist = new();
                            int temp;
                            while ((temp = stream.ReadByte()) != -1)
                            {
                                bytelist.Add((byte)temp);
                            }
                            return bytelist.ToArray();
                        });
                  
                    

                   

                    //测试用的
                  await  File.WriteAllBytesAsync("./miners/"+FileName, buff);

                    _shellWindow.ShowMessage("提示", "预下载核心完成!");
                }
                catch (Exception ex)
                {

                    _shellWindow.ShowMessage("错误", "预下载核心失败!");
                }
                finally
                {
                    reader?.Dispose();
                    stream?.Dispose();

                }


          
        }
        #endregion









        public void OnNavigatedTo(object parameter)
        {
          
             
        }

        public void OnNavigatedFrom()
        {

        }
    }







    public partial class 新增挖矿模板ViewModel
    {





        public List<币种Item> 默认模板币种列表 { get; set; }

        public 币种Item 选中币种Item { get; set; }
        public 矿池Item 选中币种矿池Item { get; set; }
        public 核心下载地址Item 选中核心下载地址Item { get; set; }

       
        


    }

    public partial class 新增挖矿模板ViewModel
    {



    }


}

