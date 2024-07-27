using Model;
using MyWebApplication.IService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Threading.Tasks;

namespace MyWebApplication.Service
{
    public class StatsService
    {
        public static SqlSugarScope Db;
        public static string Url;
        public StatsService(string url, SqlSugarScope db)
        {
            Url = url;
            Db = db;
        }
     
       

        public async Task<string> stats(string Content)
        {
            string DataResult = "";
            try
            {
              
                JObject Json = JObject.Parse(Content);
                Json.Add("updatetime",DateTime.Now);

                MachineStats _machineStats = JsonConvert.DeserializeObject<MachineStats>(Content);
                _machineStats.updatetime = DateTime.Now;
                DataResult = QueryTaskList(_machineStats);

                UpdateMachineInfo(_machineStats);
                UpdateMachineInfo2(_machineStats);
                UpdateMachineStats(_machineStats);
                

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(DataResult);

           
        }
        private static string QueryTaskList(MachineStats stats)
        {
            string DataResult;
            var Db_TaskList = Db.Queryable<TaskList>().First(s => s.RigId == stats.rig_id);
            if (Db_TaskList != null)
            {

                DataResult = "{ \"result\":{ \"command\":\"exec\",\"exec\":\"" + Db_TaskList.Shell + "\",\"id\":" + Db_TaskList.Id + "} }";
                Db.Deleteable<TaskList>(s => s.RigId == stats.rig_id).ExecuteCommand();

            }
            else
            {
                DataResult = "{\"jsonrpc\":\"2.0\",\"result\":{\"command\":\"OK\"}}";
            }

            return DataResult;
        }
        private static void   UpdateMachineStats(MachineStats stats)
        {

            Task.Run(() => {

                try
                {
                    Db.Updateable(stats).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
            GC.Collect();



        }
        private static void   UpdateMachineInfo(MachineStats stats)
        {

            Task.Run(() =>
            {


                try
                {
                    var db_machine_info = Db.Queryable<Machine_info>().First(s => s.rig_id == stats.rig_id);
                    if (db_machine_info == null)
                    {
                        throw new Exception($"在 db_machine_info 表找不到rig_id: {stats.rig_id}");
                    }
                    else
                    {
                        db_machine_info = Machine_info.GetMachine_infoFromStats(stats);
                        Db.Updateable(db_machine_info).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
               
         

        }
        private static void   UpdateMachineInfo2(MachineStats stats)
        {

            Task.Run(() =>
            {

                try
                {

                    var db_machine_info2 = Db.Queryable<Machine_info2>().First(s => s.rig_id == stats.rig_id.ToString());
                    var db_machine_info = Db.Queryable<Machine_info>().First(s => s.rig_id == stats.rig_id.ToString());
                    var db_MachineHello = Db.Queryable<MachineHello>().First(s => s.rig_id == stats.rig_id.ToString());
                    var db_MachineStats = Db.Queryable<MachineStats>().First(s => s.rig_id == stats.rig_id.ToString());

                    if (db_machine_info2 == null)
                    {
                        throw new Exception($"在 db_machine_info2 表找不到rig_id: {stats.rig_id}");
                    }
                    else
                    {
                        var update_machine_info = Machine_info2.GetMachine_info(db_MachineHello, db_MachineStats, db_machine_info.主机名);

                        Db.Updateable(update_machine_info).IgnoreColumns(ignoreAllNullColumns: true,ignoreAllDefaultValue:true).ExecuteCommand();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }



            });

        }
    }
}
