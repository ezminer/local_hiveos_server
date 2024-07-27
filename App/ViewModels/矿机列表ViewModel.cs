using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SqlSugar;


using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Contracts.Views;
using MyApp.Models;
using Model;

using DB.IService;
using DB.service;
using System.Timers;
using MyApp.Core.Contracts.Services;

namespace MyApp.ViewModels
{
    public class 矿机列表ViewModel : ObservableObject, INavigationAware
    {
        private readonly IShellWindow _shellWindow;
        private readonly IMachineData _data;
        
        private readonly SqlSugarScope _db;

       static Timer Timer { get; set; }=new Timer();
        public 矿机列表ViewModel(IShellWindow shellWindow ,SqlSugarScope db)
        {
            启用命令 = false;
            _shellWindow = shellWindow;
            _data = new MachineData(db);
            _db = db;
           
            InitCMD();

            Timer.Enabled = true;
            Timer.Interval = 15 * 1000;
            Timer.Elapsed-=Timer_Elapsed;
            Timer.Elapsed += Timer_Elapsed;
        }
        ~矿机列表ViewModel()
        {
            Timer.Dispose();
        }
        /// <summary>
        /// 定时刷新矿机列表的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           await App.Current.Dispatcher.Invoke(async () =>{

                _shellWindow.StartLoad();
                IEnumerable<Machine_info> 符合列表 = _data.GetList();

                矿机列表.Clear();
                GC.Collect();
                foreach (var item in 符合列表)
                {
                    矿机列表.Add(item);
                    await Task.Delay(2);
                }
                SelectAll = false;
                base.OnPropertyChanged("矿机列表");
                base.OnPropertyChanged("总数量");
                base.OnPropertyChanged("在线数量");
                base.OnPropertyChanged("离线数量");
                base.OnPropertyChanged("异常数量");
                GC.Collect();
                SelectAll = false;
                _shellWindow.StopLoad();


            });
        }




        //正序/逆序
        private bool 状态, 算力, 接受率, 温度, 显卡, 挖矿时长, 模板, IP;
        private bool 启用命令;
        public string 查询内容 { get; set; }
        public string 自定义命令码 { get; set; }
        public int 总数量 => 矿机列表?.Count ?? 0; 
        public int 在线数量 =>_data.GetONlineCount();
        public int 离线数量 => _data.GetOfflineCount();
        public int 异常数量 => _data.GetErrorCount();
        public string 矿机总算力 => _data.GetAllTotal();

        private bool _SelectAll;
        public bool SelectAll { get=>_SelectAll ; set=>SetProperty(ref _SelectAll,value); }
        public Machine_info 选中条目 { get; set; }
        public Mining 选中Mining { get; set; }
        public Overclocking 选中Overclocking { get; set; }
        public List<Mining> MiningList { get; set; }
        public List<Overclocking> OverclockingList { get; set; }
        public ObservableCollection<Machine_info> 矿机列表 { get; set; }=  new();
        public List<Machine_info> 选中列表 => 矿机列表?.Where(s => s.IsSelect)?.ToList()??null;


        #region 命令

        public RelayCommand 查看状态命令 { get; set; }
        public RelayCommand 自定义命令 { get; set; }
        public RelayCommand 设置命令 { get; set; }
        public RelayCommand 全选命令 { get; set; }
        public RelayCommand 查询命令 { get; set; }
        public RelayCommand 挖矿模板命令 { get; set; }
        public RelayCommand 超频模板命令 { get; set; }
        public RelayCommand<string> 空命令 { get; set; }
        public RelayCommand<string> 批量命令 { get; set; }
        public RelayCommand<string> 单个命令 { get; set; }
        public RelayCommand<string> 排序命令 { get; set; }
        public RelayCommand<string> 删除命令 { get; set; }
        public RelayCommand<string> 批量删除命令 { get; set; }
        #endregion
        private void InitCMD()
        {
        查看状态命令 = new(查看状态命令动作);
        自定义命令 = new(自定义命令动作);
        挖矿模板命令 = new(挖矿模板命令动作);
        超频模板命令 = new(超频模板命令动作);
        设置命令 = new(设置命令动作);
        批量删除命令 = new(批量删除命令动作, 验证批量命令);
        删除命令 = new(删除命令动作);
        批量命令 = new(批量命令动作, 验证批量命令);
        单个命令 = new(单个命令动作);         
        空命令 = new((s) => { },   验证批量命令);
        全选命令 = new(全选命令动作, 验证全选命令);
        排序命令 = new(排序命令动作, 验证排序命令);
        查询命令 = new(查询命令动作, 验证查询命令);
           

        }

        public bool 验证全选命令()=> 启用命令;
        public bool 验证排序命令(string s) => 启用命令;
        public bool 验证查询命令() => 启用命令;
        public bool 验证批量命令( string str)
        {
            return 选中列表?.Count > 0;
        }
        public  void 批量命令动作(string obj) {
            _shellWindow.StartLoad();
            try
            {
                _data.AddCommand(选中列表, obj);
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送命令成功!");           
            }
            catch (Exception ex)
            {
                this.LogException( ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送命令失败!");
            }
            _shellWindow.StopLoad();
        }
        public  void 单个命令动作(string obj)
        {
            _shellWindow.StartLoad();

            try
            {
                _data.AddCommand(new() { 选中条目}, obj);
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送命令成功!");
                
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送命令失败!");
            }
            _shellWindow.StopLoad();
            _shellWindow.StopLoad();
        }
        public  void 批量删除命令动作(string obj)
        {
            _shellWindow.StartLoad();



            try
            {
                _data.Delete(选中列表);              
                查询内容 = "";
                查询命令动作();
                _shellWindow.ShowMessage($"{DateTime.Now}", "删除成功!");
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "删除失败!");
            }
            _shellWindow.StopLoad();
        }
        public  void 删除命令动作(string obj)
        {
         
           _shellWindow.StartLoad();
          

            try
            {

                _data.Delete(new() { 选中条目});
                查询内容 = "";

                查询命令动作();
                _shellWindow.ShowMessage($"{DateTime.Now}", "删除成功!");
            }
            catch (Exception ex)
            {
               this.LogException(ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "删除成功!");

            }
            _shellWindow.StopLoad();

        }
        public  void 自定义命令动作()
        {
            _shellWindow.StartLoad();
          
            try
            {

                _data?.AddCommand(选中列表,自定义命令码);
              _shellWindow.ShowMessage($"{DateTime.Now}", $"发送命令:{自定义命令码} 成功!");
            }
            catch (Exception ex)
            {
               this.LogException(ex);
                MessageBox.Show(ex.Message);
                _shellWindow.ShowMessage($"{DateTime.Now}", $"发送命令:{自定义命令码} 失败!");
            }
            _shellWindow.StopLoad();
        }      
        public   void 设置命令动作()
        {        
            _shellWindow.NavigationService.NavigateTo(typeof(矿机设置ViewModel).FullName, 选中条目.rig_id);
           
        }
        public void 查看状态命令动作()
        {
            _shellWindow.NavigationService.NavigateTo(typeof(矿机详细信息ViewModel).FullName, 选中条目, true);
        }
        public async void 查询命令动作()
        {
            _shellWindow.StartLoad();
            IEnumerable<Machine_info> 符合列表 = null;
            if (!string.IsNullOrWhiteSpace(查询内容))
            {

                符合列表 = _data.GetList(查询内容);

            }
            else
            {
                符合列表 = _data.GetList();
            }       
            矿机列表.Clear();
            GC.Collect();
            foreach (var item in 符合列表)
            {
                矿机列表.Add(item);
                await Task.Delay(2);
            }                     
            SelectAll = false;
            base.OnPropertyChanged("矿机列表");
            base.OnPropertyChanged("总数量");
            base.OnPropertyChanged("在线数量");
            base.OnPropertyChanged("离线数量");
            base.OnPropertyChanged("异常数量");
            OnPropertyChanged(nameof(矿机总算力));
            GC.Collect();
            SelectAll=false;
            _shellWindow.StopLoad();
        }
        private static string _Config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/rig.conf.txt");
        private static string _Amd = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/amd-oc.conf.txt");
        private static string _Nvidia = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/nvidia-oc.conf.txt");
        private static string _Wallet = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/wallet.conf.txt");
        private static string _Autofan = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/autofan.conf.txt");  
        public  void 挖矿模板命令动作()
        {
            _shellWindow.StartLoad();
            try
            {

                _data.UpdateMinng(选中列表, 选中Mining);

               
            }
            catch (Exception ex)
            {
                // File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + $"log目录/{DateTime.Now.ToShortTimeString()}.txt", ex.StackTrace);
               this.LogException(ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
            }

            批量命令动作("刷新");

            _shellWindow.StopLoad();
        }
        public  void 超频模板命令动作()
        {

            _shellWindow.StartLoad();
            try
            {
                _data.UpdateOverclocking(选中列表, 选中Overclocking);
            }
            catch (Exception ex)
            {
                _db.Ado.RollbackTran();
               this.LogException(ex);
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
            }
            批量命令动作("刷新");
            _shellWindow.StopLoad();
            SelectAll = false;

          

        }
        public async  void 全选命令动作()
        {
         
            foreach (var item in 矿机列表)
            {
                item.IsSelect = SelectAll;
                
            }
            OnPropertyChanged(nameof(矿机列表));
          await  Task.CompletedTask;
        }
        public async void 排序命令动作(string content)
        {
            _shellWindow.StartLoad();
            if (content == nameof(状态))
            {
                await 矿机列表.SortAsync(s => s.状态, 状态);
                状态 = !状态;
               

            }
            if (content == nameof(算力))
            {
                await 矿机列表.SortAsync(s => s.算力, 算力);
                算力 = !算力;
            }
            if (content == nameof(接受率))
            {
                await 矿机列表.SortAsync(s => s.接受率, 接受率);
                接受率 = !接受率;
            }
            if (content == nameof(温度))
            {
                await 矿机列表.SortAsync(s => s.温度, 温度);
                温度 = !温度;
            }
            if (content == nameof(挖矿时长))
            {
                await 矿机列表.SortAsync(s => s.挖矿时长, 挖矿时长);
                挖矿时长 = !挖矿时长;
            }
            if (content == nameof(模板))
            {
                await 矿机列表.SortAsync(s => s.模板, 模板);
                模板 = !模板;
            }
            if (content == nameof(显卡))
            {
                await 矿机列表.SortAsync(s => s.显卡, 显卡);
                显卡 = !显卡;
            }
            if (content == nameof(IP))
            {
                await 矿机列表.SortAsync(s => s.IP, IP);
                IP = !IP;
            }
       
            GC.Collect();
            _shellWindow.StopLoad();
        }
        public async Task LoadAsync()
        {
           // _shellWindow.StartLoad();
            MiningList = await _db.Queryable<Mining>().ToListAsync(); ;
            OverclockingList =await _db.Queryable<Overclocking>().ToListAsync(); 
            var list = await _db.Queryable<Machine_info>().ToListAsync(); 

            矿机列表.Clear();            
            foreach (var item in list)
            {
                矿机列表.Add(item);
                await Task.Delay(2);
            }

            base.OnPropertyChanged(nameof(MiningList));
            base.OnPropertyChanged(nameof( OverclockingList));
            base.OnPropertyChanged(nameof(矿机列表));
            base.OnPropertyChanged(nameof(总数量));
            base.OnPropertyChanged(nameof(在线数量));
            base.OnPropertyChanged(nameof(离线数量));
            base.OnPropertyChanged(nameof(异常数量));
            
            启用命令 = true;
            全选命令.NotifyCanExecuteChanged();
            查询命令.NotifyCanExecuteChanged();
            排序命令.NotifyCanExecuteChanged();
            //_shellWindow.StopLoad();

        }


        //public 


        public void OnNavigatedTo(object parameter)
        {
      
        }     
        public void OnNavigatedFrom()
        {
            GC.Collect();
        }

      
    }
}
