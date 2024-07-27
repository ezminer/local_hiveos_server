using DB.service;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyApp.Contracts.Views;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MyApp.ViewModels
{
    public class CustomCMDDialogViewModel: ObservableObject
    {

        private readonly MachineData _data;
        private readonly IShellWindow _shellWindow;
        public RelayCommand 自定义命令 { get; set; }

        public CustomCMDDialogViewModel(IShellWindow shellWindow, SqlSugarScope db)
        {
            
            _data = new MachineData(db);
            _shellWindow = shellWindow;

            自定义命令 = new RelayCommand(自定义命令动作);


        }
        private string Rig_id;
         
        public Task LoadAsync(string rig_id)
        {

            this.Rig_id = rig_id;
            return Task.CompletedTask;

        }
        public string 自定义命令码 { get; set; }

        public void 自定义命令动作()
        {
           
            try
            {
      
                _data?.AddCommand(new List<Model.Machine_info>() { new() { rig_id= this.Rig_id } }, 自定义命令码);
                _shellWindow.ShowMessage($"{DateTime.Now}", $"发送命令:{自定义命令码} 成功!");
            }
            catch (Exception ex)
            {
              
                _shellWindow.ShowMessage($"{DateTime.Now}", $"发送命令:{自定义命令码} 失败!");
            }
           
        }
    }
}
