
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MyApp;
using MyApp.Core.Contracts.Services;
using MyApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class ObservableExtension
{
    public static async Task SortAsync<L,T>(this ObservableCollection<L> collection,Func<L, T> p,bool Descending=false)
    {
        List<L> sorted;
        if (Descending)
        {
            sorted = collection.OrderByDescending(p).ToList();
        }
        else
        {
            sorted = collection.OrderBy(p).ToList();

        }
        for (int newIndex = 0; newIndex < sorted.Count(); newIndex++)
        {
            //  await  Task.Delay(1);
            int oldIndex = collection.IndexOf(sorted[newIndex]);
            if (oldIndex != newIndex)
                collection.Move(oldIndex, newIndex);
        }
        GC.Collect();
    }
}

    public static class ObjectLogExtensions
{

    static IMyLog log = (App.Current as App).GetService<IMyLog>();
    public static void LogException(this object obj,Exception ex,string msg=null)
    {
        try
        {
            log.WriteException(msg, ex);
        }
        catch (Exception)
        {

           
        }
      
    }
    public static void LogINFO(this object obj,string msg)
    {
        log.WriteINFO(msg);
    }
    public static void LogDebug(this object obj, string msg)
    {
        log.WriteDebug(msg);
    }
    public static void LogWRAN(this object obj, string msg)
    {
        log.WriteWRAN(msg);
    }
    public static void LogERROR(this object obj, string msg)
    {
        log.WriteERROR(msg);
    }
    public static void LogFATAL(this object obj, string msg)
    {
        log.WriteFATAL(msg);
    }

}



namespace MyApp.Helpers
{
    public static class Helper
    {
       

       public static T DeepCopy<T>( T  obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }
        
       


    }
   
    }
