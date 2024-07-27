using Model;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace DB.IService
{




    public interface IMachineData
    {

       List<Machine_info> GetList();
       List<Machine_info> GetList(string QueryContent);
       int GetOfflineCount();
       int GetONlineCount();
       int GetErrorCount();
        string GetAllTotal();
       int GetCount();
       bool Delete(List<Machine_info> updateList);

        bool AddCommand(List<Machine_info> updateList, string shell);
       bool UpdateMinng(List<Machine_info> updateList, Mining mining);
       bool UpdateOverclocking(List<Machine_info> updateList, Overclocking overclocking);
    }


    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public Repository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {

            base.Context = context;//ioc注入的对象
                                   // base.Context=DbScoped.SugarScope; SqlSugar.Ioc这样写
                                   // base.Context=DbHelper.GetDbInstance()当然也可以手动去赋值
        }

     

    }



}
