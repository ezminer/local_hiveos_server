using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using SqlSugar;

using MyApp.Contracts.Services;
using MyApp.Contracts.ViewModels;
using MyApp.Contracts.Views;
using MyApp.DataRepositories.Model;

namespace MyApp.ViewModels
{
    public class 新增超频模板ViewModel : ObservableObject, INavigationAware
    {
        private readonly SqlSugarScope _db;
       
        private readonly IShellWindow _shellWindow;

        public 新增超频模板ViewModel(IShellWindow shellWindow, SqlSugarScope db)
        {
            _db = db;
               _shellWindow = shellWindow;
        }

        public Overclocking Model { get; set; } = new();
        private 操作模式 _Mode;
        public 操作模式 操作模式 { get => _Mode; set => SetProperty(ref _Mode, value); }
        #region 添加命令
        private ICommand _返回命令;
        public ICommand 返回命令 => _返回命令 ?? (_返回命令 = new RelayCommand<object>(返回命令动作));
        public void 返回命令动作(object obj)
        {
            _shellWindow.NavigationService.NavigateTo(typeof(超频模板列表页ViewModel).FullName);
          
        }

        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public void 添加命令动作(object obj)
        {
            var x = _db.Storageable(Model).ToStorage(); //将数据进行分组 
            var x1 = x.AsInsertable.ExecuteCommand(); //执行插入 （可以换成雪花ID和自增）
            var x2 = x.AsUpdateable.ExecuteCommand(); //执行更新　
            if (x1 > 0 || x2 > 0)
            {
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存成功!");
            }
            else
            {
                _shellWindow.ShowMessage($"{DateTime.Now}", "保存失败!");
            }
        }
        #endregion



        public void OnNavigatedTo(object parameter)
        {
            if (parameter is int id)
            {
                Model = null;
                操作模式 = 操作模式.修改;
                Model = _db.Queryable<Overclocking>().First(s=>s.Id==id);
                OnPropertyChanged(nameof(Model));

            }
            else
            {
                操作模式 = 操作模式.新增;
                
            }
        }

        public void OnNavigatedFrom()
        {
           
        }
    }
}
