using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using SqlSugar;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.Core.Contracts.Services;

using MyApp.DataRepositories.Model;
using MyApp.Models;

namespace MyApp.ViewModels
{
    public class 挖矿模板列表页ViewModel : ObservableObject
    {
  
        private readonly INavigationService _navigationService;
        private readonly SqlSugarScope _db;
        private readonly IShellWindow _shellWindow;
        public 挖矿模板列表页ViewModel( SqlSugarScope db, IShellWindow shellWindow,
            INavigationService navigationService)
        {
            _db=db;
             _shellWindow = shellWindow;
            _navigationService = navigationService;
        }
       
        public Mining SelectedItem { get; set; }
        public ObservableCollection<Mining> List { get; set; }

        public Mining SelectedCustomItem { get; set; }
        public ObservableCollection<Mining> CustomList { get; set; }


        public async Task LoadAsync()
        {
            var list = await _db.Queryable<Mining>().ToListAsync();//_repository.GetListAsync();

            List = new(list.Where(s=>s.默认模板==0));
            CustomList = new(list.Where(s => s.默认模板 == 1));
            OnPropertyChanged(nameof(List));
            OnPropertyChanged(nameof(CustomList));
        }
        #region 添加命令
        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public void 添加命令动作(object obj)
        {
            //
            _navigationService.NavigateTo(typeof(新增挖矿模板ViewModel).FullName);


        }
        #endregion
        #region 删除命令
        private RelayCommand _删除命令;
        public RelayCommand 删除命令 => _删除命令 ?? (_删除命令 = new RelayCommand(删除命令动作, 可以操作));
        public bool 可以操作()
        {

            return SelectedItem!=null ;
        }
        public void 删除命令动作()
        {
            _shellWindow.StartLoad();

            try
            {
                if (_db.Deleteable<Mining>(SelectedItem).ExecuteCommand()>0)
                {
                    List.Remove(SelectedItem);
                    _shellWindow.ShowMessage($"{DateTime.Now}", "删除成功!");
                  
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                _shellWindow.ShowMessage($"{DateTime.Now}", "删除失败!");
            }
            _shellWindow.StopLoad();
            GC.Collect();
        }

        #endregion
        #region 修改命令
        private RelayCommand _修改命令;
        public RelayCommand 修改命令 => _修改命令 ?? (_修改命令 = new RelayCommand(修改命令动作, 可以操作));
        public void 修改命令动作()
        {

            _shellWindow.StartLoad();

            try
            {
                if (_db.Updateable<Mining>(SelectedItem).ExecuteCommand()>0)
                {
                    
                    _shellWindow.ShowMessage($"{DateTime.Now}", "更新成功!");

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                _shellWindow.ShowMessage($"{DateTime.Now}", "更新失败!");
            }
            _shellWindow.StopLoad();
            GC.Collect();
        }

        #endregion
        #region 删除命令
        public bool 可以操作2()
        {

            return SelectedCustomItem != null;
        }
        private RelayCommand _删除命令2;
        public RelayCommand 删除命令2 => _删除命令2 ?? (_删除命令2 = new RelayCommand(删除命令动作2, 可以操作2));
      
        public void 删除命令动作2()
        {
            _shellWindow.StartLoad();

            try
            {
                if (_db.Deleteable<Mining>(SelectedCustomItem).ExecuteCommand() > 0)
                {
                    CustomList.Remove(SelectedCustomItem);
                    _shellWindow.ShowMessage($"{DateTime.Now}", "删除成功!");

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                _shellWindow.ShowMessage($"{DateTime.Now}", "删除失败!");
            }
            _shellWindow.StopLoad();
            GC.Collect();
        }

        #endregion
        #region 修改命令
        private RelayCommand _修改命令2;
        public RelayCommand 修改命令2 => _修改命令2 ?? (_修改命令2 = new RelayCommand(修改命令动作2, 可以操作2));
        public void 修改命令动作2()
        {

            _shellWindow.StartLoad();

            try
            {
                if (_db.Updateable<Mining>(SelectedCustomItem).ExecuteCommand() > 0)
                {

                    _shellWindow.ShowMessage($"{DateTime.Now}", "更新成功!");

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                _shellWindow.ShowMessage($"{DateTime.Now}", "更新失败!");
            }
            _shellWindow.StopLoad();
            GC.Collect();
        }

        #endregion

    }
}
