using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyApp.Contracts.Services;

namespace MyApp.Services
{
    internal class TimerTaskService : ITimerTaskService
    {
      

        public TimerTaskService()
        {
         
            Run();
        }
        public void Run()
        {
         MyTask=new(清理任务);
         
         MyTask.Start();
            
        }
        public void Stop()
        {
            MyTask?.Dispose();
        }
        Task MyTask;
        private async void 清理任务()
        {
            var i = 0;
            while (true)
            {
                
                if (i >= 10)
                {
                    i=0;

                    Console.WriteLine($"{DateTime.Now}:开始清理一轮任务");
                    //await _repository_TaskList.DeleteAsync(
                    //     s => SqlFunc.SqlServer_DateDiff("minute", s.Addtime.Value, DateTime.Now) >= 2

                    //     );


                    //_messageDialogService.ShowMessage($"清理任务", $"{DateTime.Now}");

                    Console.WriteLine($"{DateTime.Now}: {this.GetHashCode()},成功清理一轮任务");
                    GC.Collect();
                }
                          
                await Task.Delay(1000 * 10);
                i++;



            }
        }

       
    }
}
