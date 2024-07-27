using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SqlSugar;

using MyApp.Contracts.Services;
using MyApp.Controls;
using MyApp.Core.Contracts.Services;

using MyApp.Models;

namespace MyApp.ViewModels
{

    public class 钱包模板列表页ViewModel : ObservableObject
    {
      
        private readonly INavigationService _navigationService;
        private readonly SqlSugarScope _db;
        public 钱包模板列表页ViewModel(INavigationService navigationService,
            SqlSugarScope db)
        {
                 _db= db;
            _navigationService = navigationService;
         


        }
      
       // public List<Wallet> List { get; set; }
        public QBModel SelectedItem { get; set; }
        /// <summary>
        /// 需要存在对象才可以绑定
        /// </summary>
        public List<QBModel> SelectedItems { get; set; } = new ();
   
        public async Task LoadcmdAysnc()
        {
            //List= await _repository.GetListAsync();
            //OnPropertyChanged(nameof(List));
            //GC.Collect();          
        }
        #region 删除命令
        private RelayCommand<object> _删除命令;
        public RelayCommand<object> 删除命令 => _删除命令 ?? (_删除命令 = new RelayCommand<object>(删除命令动作, 可以删除));
       public bool 可以删除( object obj) {

            return SelectedItems?.Count > 0;
        }
        public void 删除命令动作(object obj)
        {
           
           foreach (var item in SelectedItems.ToArray())
                {
                
                }          
            GC.Collect();
        }

        #endregion
        #region 添加命令
        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public void 添加命令动作(object obj)
        {
            //
            _navigationService.NavigateTo(typeof(新增钱包模板ViewModel).FullName);


        }

        #endregion
        #region 修改命令
        private ICommand _修改命令;
        public ICommand 修改命令 => _修改命令 ?? (_修改命令 = new RelayCommand<object>(修改命令动作));
        public void 修改命令动作(object obj) {
            if(SelectedItem==null) return;
            _navigationService.NavigateTo(typeof(新增钱包模板ViewModel).FullName,SelectedItem.ID);
        }
        
        #endregion

    }


}
