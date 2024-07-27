using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using SqlSugar;
using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Contracts.Views;

namespace MyApp.ViewModels
{
    public class 矿机设置ViewModel : ObservableObject, INavigationAware
    {
        private readonly IShellWindow _shellWindow;
        private readonly INavigationService _navigationService;
        private readonly SqlSugarScope _db;
        public 矿机设置ViewModel(
          
            SqlSugarScope sugarScope,
           IShellWindow shellWindow,
            INavigationService navigationService )
        {
            _db = sugarScope;
            _shellWindow = shellWindow;
              _navigationService = navigationService;
        }
       public MachineUserSetting Model { get; set; }
        public Mining SelectMining { get; set; }
        public List<Mining> MiningList { get; set; }
        public string Stats { get; set; }
        public Machine_info Db_Machine_info { get; set; }
        public Machine_info2 Db_Machine_info2 { get; set; }
        public async Task LoadAsync()
        {
        }


    
        #region 添加命令
        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public async void 添加命令动作(object obj)
        {
            try
            {

              //开启事务
                _db.Ado.BeginTran();
                //更新 MachineuserConfig
                await _db.Updateable(Model).ExecuteCommandAsync();

                var 核心下载地址 = SelectMining.MinerverAddr;

                var machineConfig = new MachineConfig()
                {
                    Id = int.Parse(Model.rig_id),
                    RigName = Model.RigName,
                    Config = MachineConfig.GetRigconfTemplate(
                        Config.Default.SERVERIP, Model.rig_id,
                         Model.RigName, SelectMining.password)


                    ,
                    AmdOc = MachineConfig.GetAmd_ocTemplate(Model)
                        //,
                        //Autofan = _Autofan
                        ,
                    NvidiaOc = MachineConfig.GetNvidia_ocTemplate(Model)
                    ,

                    Wallet = MachineConfig.GetWalletTemplate(SelectMining,Model.rig_id,Model.RigName)
                
                    , Autofan = MachineConfig.GetAutoFanTemplate(),
                    Addtime = DateTime.Now.ToString("g")
              };
                Db_Machine_info.模板 = SelectMining.MiningName;
                Db_Machine_info.主机名 = Model.RigName;
                Db_Machine_info.备注 = Model.Other;
                Db_Machine_info2.挖矿模板 = SelectMining.MiningName;
                Db_Machine_info2.主机名 = Model.RigName;
                await _db.Updateable(Db_Machine_info).ExecuteCommandAsync();
              
                var _i=await _db.Updateable(Db_Machine_info2).
                    UpdateColumns(it => new { it.主机名, it.挖矿模板 }).
                    ExecuteCommandAsync();



                _db.Updateable(machineConfig).ExecuteCommand();
                _db.Insertable(new TaskList()
                    {
                        Addtime = DateTime.Now,
                        Passwd = SelectMining.password,
                        RigId = Model.rig_id,
                        Shell = "hello"
                    }).ExecuteCommand();
                _shellWindow.ShowMessage("更新成功", $"主机名:{Model.RigName}");

                _db.Ado.CommitTran();

               


            }
            catch (Exception ex)
            {

                _db.Ado.RollbackTran();
                _shellWindow.ShowMessage("错误", ex.Message);
               // throw ex;
            }

           
            
        }

        private ICommand _返回命令;
        public ICommand 返回命令 => _返回命令 ?? (_返回命令 = new RelayCommand<object>(返回命令动作));
        public void 返回命令动作(object obj)
        {
            //
        _navigationService.NavigateTo(typeof(矿机列表ViewModel).FullName,clearNavigation:true);
        }

        #endregion
        public void OnNavigatedFrom()
        {
           
        }

        public async void OnNavigatedTo(object parameter)
        {

            if (parameter is string RigId)
            {
                
                MiningList = await _db.Queryable<Mining>().ToListAsync();
                Model = await _db.Queryable<MachineUserSetting>().FirstAsync(s=>s.rig_id == RigId);
                Db_Machine_info = await _db.Queryable<Machine_info>().FirstAsync(s => s.rig_id == RigId);
                Db_Machine_info2= await _db.Queryable<Machine_info2>().FirstAsync(s => s.rig_id == RigId);
                Model.RigName = Db_Machine_info.主机名;
                SelectMining= MiningList.FirstOrDefault(s=>s.MiningName== Db_Machine_info.模板);
                Stats = Db_Machine_info.状态;
                OnPropertyChanged(nameof(Stats));
                OnPropertyChanged(nameof(MiningList));
                OnPropertyChanged(nameof(SelectMining));
                OnPropertyChanged(nameof(Model));
                
            }
        }
    }
}
