using Model;
using MyWebApplication.IService;
using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebApplication.Service
{

    
    public class SQLQueueService: ISQLQueueService 
    {
        private readonly SqlSugarScope _db;

        private Queue<Action<object>>  sqlQueue=new() ;

        public SQLQueueService(SqlSugarScope db)
        {
            _db = db;

            //定时五分钟
            Timer = new Timer(TimerCallback, null, 0, 1000 * 60 * 5);
           
        }
        ~SQLQueueService()
        {
            run = false;
        }

 
        Timer Timer;
        private bool run=false;

        readonly string path = AppDomain.CurrentDomain.BaseDirectory + "算力记录//";
        public void TimerCallback(object? state)
        {

            try
            {
                var list = _db.Queryable<Machine_info>().Select(s => new { s.算力, s.rig_id,s.温度 }).ToList();


                foreach (var item in list)
                {
                    var Filepath=path+ DateTime.Now.ToString("M")+"_"+item.rig_id+".txt";

                    if (!Directory.Exists(path))
                    { 
                        Directory.CreateDirectory(path);
                    }
                    if (!File.Exists(Filepath))
                    {
                        File.Create(Filepath);
                    }

                    var str = DateTime.Now.ToString("f") + ">" + (item.算力?? "0Khs")+">"+(item.温度 ?? "0℃\n");
                   

                    File.AppendAllText(Filepath, str);


                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
        public void RunSQLQueueService()
        {
            if (run) return;
            run = true;
            _ = Task.Run(async () =>
            {
                Thread.CurrentThread.Name = "SQl队列线程";

                while (true)
                {

                    try
                    {


                        离线检查();
                        离线清零();

                        await Task.Delay(1000 * 30);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }


                }




            });
                
           

        }

        private void 离线检查()
        {
            DateTime dateTime = DateTime.Now.AddSeconds(-30);

            _db.Updateable<Machine_info>().SetColumns(it => new() { 状态 = "离线" }).Where(
                s => SqlFunc.Subqueryable<MachineStats>().Where(i => i.updatetime <= dateTime && i.rig_id == s.rig_id).Any()
            ).ExecuteCommand();

        }
        private void 离线清零()
        {

            string[] 离线列表 = _db.Queryable<Machine_info>().Where(s => s.状态 == "离线").Select(s => s.rig_id).ToArray();

            _db.Updateable(new Machine_info2())
                .UpdateColumns(it => new 
                {
                    it.在线时长,
                    it.挖矿时长

                })              
                .Where(s => 离线列表.Contains(s.rig_id)).ExecuteCommand();

            _db.Updateable(new Machine_info()).UpdateColumns(it => new { it.温度,it.算力,it.挖矿时长,it.接受率}).Where(s => 离线列表.Contains(s.rig_id)).ExecuteCommand();
            _db.Updateable(new MachineHello())
                .UpdateColumns(it => new
                {
                    it.boot_time,
                    

                })
                .Where(s => 离线列表.Contains(s.rig_id)).ExecuteCommand();

        }



        
    }
       
    
}
