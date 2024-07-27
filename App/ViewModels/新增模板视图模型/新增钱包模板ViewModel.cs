using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyApp.Contracts.ViewModels;

using MyApp.Models;

namespace MyApp.ViewModels
{
   public enum 操作模式
    {
        新增,
        修改,

    }
    public class 新增钱包模板ViewModel : ObservableObject, INavigationAware
    {
     
        private QBModel _Model;
        public QBModel Model { get=> _Model; set=>SetProperty(ref _Model,value); }
        private 操作模式 _Mode;
        public 操作模式 操作模式 { get => _Mode; set => SetProperty(ref _Mode, value); } 
        
        private ICommand _添加命令;
        public ICommand 添加命令 => _添加命令 ?? (_添加命令 = new RelayCommand<object>(添加命令动作));
        public void 添加命令动作(object obj)
        {
            //if (_Mode==操作模式.新增)
            //{
            //    try
            //    {
            //        if (_repository.Insert(Model))
            //        {
            //            MessageBox.Show("添加成功");
            //        }
            //        else
            //        {
            //            MessageBox.Show("添加失败");
            //        }

            //    }
            //    catch (Exception ex)
            //    {
                   
            //        MessageBox.Show(ex.InnerException.Message.ToString());
            //    }finally
            //    {
            //        Model = new();
            //    }
            //}
            //else if(_Mode == 操作模式.修改)
            //{
            //    if (_repository.Update(Model.ID,Model.Copy()))
            //    {
                   
            //        MessageBox.Show("修改成功");
            //    }
            //    else
            //    {
            //        MessageBox.Show("修改上报");
            //    }

            //}
           

        }

        public void OnNavigatedTo(object parameter)
        {
           if(parameter is int id)
            {
               操作模式 = 操作模式.修改;
              // Model =_repository.GetModelByID(id);

            }
            else
            {
                操作模式 = 操作模式.新增;
                Model = new();
            }
        }

        public void OnNavigatedFrom()
        {
          
        }
    }
}
