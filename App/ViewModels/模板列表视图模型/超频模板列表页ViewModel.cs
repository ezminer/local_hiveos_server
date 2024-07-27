using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using SqlSugar;
using MyApp.Contracts.Services;
using MyApp.Contracts.Views;
using MyApp.DataRepositories.Model;

namespace MyApp.ViewModels
{
    public class 超频模板列表页ViewModel : ObservableObject
    {
        private readonly IShellWindow _shellWindow;
      //  private readonly Repository<Overclocking> _repository;
        private readonly SqlSugarScope _db;
        public 超频模板列表页ViewModel(IShellWindow shellWindow, SqlSugarScope db)
        {
            _db = db;
            _shellWindow = shellWindow;
        }
     
        public ObservableCollection<Overclocking> List { get; set; }
        public Overclocking SelectedItem { get; set; }
        public List<CPModel> SelectedItems { get; set; }=new();
        public async void Loadcmdasync() {
            var list = await _db.Queryable<Overclocking>().ToListAsync();//.GetListAsync();
            List = new(list);  
            OnPropertyChanged(nameof(List));

        }
        #region 添加命令
        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public void 添加命令动作(object obj)
        {
            _shellWindow.NavigationService.NavigateTo(typeof(新增超频模板ViewModel).FullName);

        }

        #endregion
        #region 删除命令
        private RelayCommand<object> _删除命令;
        public RelayCommand<object> 删除命令 => _删除命令 ?? (_删除命令 = new RelayCommand<object>(删除命令动作, 可以删除));
        public bool 可以删除(object obj)
        {

            return SelectedItem!=null;
        }
        public void 删除命令动作(object obj)
        {
            _shellWindow.StartLoad();

            try
            {
                if (_db.Deleteable<Overclocking>().ExecuteCommand()>0)
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
        private ICommand _修改命令;
        public ICommand 修改命令 => _修改命令 ?? (_修改命令 = new RelayCommand<object>(修改命令动作));
        public void 修改命令动作(object obj)
        {
            _shellWindow.StartLoad();

            try
            {
                if (_db.Updateable<Overclocking>().ExecuteCommand()>0)
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
