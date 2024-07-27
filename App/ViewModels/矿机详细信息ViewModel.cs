using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;


using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Contracts.Views;
using MyApp.Models;
using MyApp.DialogView;
using System.Timers;

namespace MyApp.ViewModels
{

    

    public class 矿机详细信息ViewModel : ObservableObject, INavigationAware
    {
        private readonly SqlSugarScope _db;
        private readonly IShellWindow _shellWindow;
        private readonly IServiceProvider _service;
        public 矿机详细信息ViewModel(IShellWindow shellWindow, SqlSugarScope db , IServiceProvider service)
        {          
            _shellWindow = shellWindow;
            _db = db;
            _service = service;
            矿机命令 = new(矿机命令动作);
            导航到设置页命令 = new(导航到设置页命令动作);
            导航到列表页命令 = new(导航到列表页命令动作);
            Timer.Enabled = true;
            Timer.Interval = 15 * 1000;
            Timer.Elapsed += Timer_Elapsed;
        }
        ~矿机详细信息ViewModel()
        {
            Timer.Dispose();
        }
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
          await  App.Current.Dispatcher.Invoke(async () => {

                Machine_info2 = await _db.Queryable<Machine_info2>().FirstAsync(s => s.rig_id == Machine_info2.rig_id);

                Machine_info = await _db. Queryable<Machine_info>().FirstAsync(s => s.rig_id == Machine_info2.rig_id);
                TaskDones = await _db.Queryable<TaskDone>().Where(s => s.RigId == Machine_info2.rig_id).ToListAsync();
                刷新时间 = "刷新时间:" + DateTime.Now.ToString("F");

              var usersetting = await _db.Queryable<MachineUserSetting>().Where(s => s.rig_id == Machine_info2.rig_id).FirstAsync();

              Mining = await _db.Queryable<Mining>().Where(s => s.Id.ToString() == usersetting.MiningId).FirstAsync();
              
               await Task.Delay(100);
                离线隐藏();
                OnPropertyChanged(nameof(Mining));
                OnPropertyChanged(nameof(Machine_info2));
                OnPropertyChanged(nameof(Machine_info));
                OnPropertyChanged(nameof(刷新时间));
                OnPropertyChanged(nameof(TaskDones));

            });
        }


        public void 离线隐藏()
        {

            if (Machine_info.状态 == "离线")
            {


                Machine_info2.挖矿时长 = "";
                Machine_info2.在线时长 = "";
                //Machine_info2.CPU核心数 = "000";
                foreach (var item in Machine_info2.显卡信息)
                {
                    item.算力 = "";
                    item.风扇 = "";
                    item.实时功耗 = "";
                }
                 
            }


        }



        public Machine_info Machine_info { get; set; }
        public Mining Mining { get; set; } 
        public string 刷新时间 { get; set; }
        Timer Timer { get; set; } = new Timer();
        public Machine_info2 Machine_info2 { get; set; }
        public List<TaskDone> TaskDones { get; set; }


        #region 清除log命令
        private RelayCommand _清除log命令;
        public RelayCommand 清除log命令 => _清除log命令 ?? (_清除log命令 = new RelayCommand(_清除log命令动作));
        public async void _清除log命令动作()
        {

         
            try
            {
               var i= await _db.Deleteable<TaskDone>(s => s.RigId == Machine_info2.rig_id).ExecuteCommandAsync();
                if (i> 0)
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "清除log成功!");
                    
                }
                else
                {
                    _shellWindow.ShowMessage($"{DateTime.Now}", "清除log失败!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _shellWindow.ShowMessage($"{DateTime.Now}", "清除log失败!");
            }


        }

        #endregion

        #region 提取log命令
        private RelayCommand _提取log命令;
        public RelayCommand 提取log命令 => _提取log命令 ?? (_提取log命令 = new RelayCommand(提取log命令动作));
        public async void 提取log命令动作()
        {
          
            try
            {

               
                await _db.Insertable(new TaskList()
                {
                    Addtime = DateTime.Now,
                    Passwd = "88888888",
                    RigId = Machine_info2.rig_id,
                    Shell = "miner log"
                }).ExecuteCommandAsync();
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _shellWindow.ShowMessage($"{DateTime.Now}", "发送失败!");
            }
           
        }

        #endregion
        #region 提取log命令
        private RelayCommand _刷新命令;
        public RelayCommand 刷新命令 => _刷新命令 ?? (_刷新命令 = new RelayCommand(刷新命令动作));
        public async void 刷新命令动作()
        {

            try
            {

                TaskDones = await _db.Queryable<TaskDone>().Where(s => s.RigId == Machine_info2.rig_id).ToListAsync();
                await Task.Delay(100);
               
                OnPropertyChanged(nameof(TaskDones));          
                _shellWindow.ShowMessage($"{DateTime.Now}", "刷新成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _shellWindow.ShowMessage($"{DateTime.Now}", "刷新成功!");
            }

        }

        #endregion

        #region 提取log命令
        private RelayCommand _自定义命令;
        public RelayCommand 自定义命令 => _自定义命令 ?? (_自定义命令 = new RelayCommand(自定义命令动作));
        public async void 自定义命令动作()
        {

            try
            {

             

              var win=  _service.GetService(typeof(CustomCMDDialogView)) as CustomCMDDialogView;
                win.Show(Machine_info2.rig_id);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }

        }

        #endregion

        public RelayCommand 导航到设置页命令 { get; set; }
        public RelayCommand 导航到列表页命令 { get; set; } 
        public void 导航到设置页命令动作()
        {
                   
             _shellWindow.NavigationService.NavigateTo(typeof(矿机设置ViewModel).FullName,Machine_info2.rig_id);

        }
        public void 导航到列表页命令动作()
        {
            _shellWindow.NavigationService.NavigateTo(typeof(矿机列表ViewModel).FullName,clearNavigation:true);
            _shellWindow.NavigationService.CleanNavigation();

        }
        public RelayCommand<string> 矿机命令 { get; set; } 
        public async void 矿机命令动作(string obj)
        {
           var cmdstring=  Enum.Parse(typeof(矿机命令码), obj).ToString();

            _shellWindow.StartLoad();

            var cmd = await _db.Queryable<Model.Action>().FirstAsync(c => c.ActionName == cmdstring.ToString());
            try
            {
                if (cmd == null) throw new Exception($"数据库 找不到 action_name为{obj}");
                TaskList taskList = new()
                {
                    Addtime = DateTime.Now,
                    Passwd =Mining.password,
                    RigId = Machine_info2.rig_id,
                    Shell = cmd.Shell
                };
                _db.Insertable(taskList).ExecuteCommand();
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存成功!");
            }
            catch (Exception ex)
            {
                
                _shellWindow.ShowMessage($"{DateTime.Now}", "失败成功!");
            }
            _shellWindow.StopLoad();

        }
 
        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is Machine_info item)
            {
               
                Machine_info2=await _db.Queryable<Machine_info2>().FirstAsync(s => s.rig_id == item.rig_id);
               
                TaskDones= await _db.Queryable<TaskDone>().Where(s => s.RigId == item.rig_id).ToListAsync();         
                var usersetting=  await _db.Queryable<MachineUserSetting>().Where(s => s.rig_id == item.rig_id).FirstAsync();
                Mining= await _db.Queryable<Mining>().Where(s => s.Id.ToString() ==usersetting.MiningId).FirstAsync();
                
                Machine_info =await _db.Queryable<Machine_info>().FirstAsync(s => s.rig_id == Machine_info2.rig_id);            
                刷新时间 = "刷新时间:" + DateTime.Now.ToString("F");
                离线隐藏();
                OnPropertyChanged(nameof(Mining));
                OnPropertyChanged(nameof(Machine_info2));
                OnPropertyChanged(nameof(TaskDones));
                OnPropertyChanged(nameof(Machine_info));
                OnPropertyChanged(nameof(刷新时间));
              

            }
        }




        public void OnNavigatedFrom()
        {
          
          

        }
    }
}
