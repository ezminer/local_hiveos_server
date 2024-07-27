using Model;
using Model.Response;
using MyWebApplication.IService;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyWebApplication.Service
{

    



    public class HelloService
    {
        public static SqlSugarScope Db;
    
        public HelloService(string url, SqlSugarScope db )
        {
            this.url = url;
            Db = db;
           
        }
        private string url;
        public Task<string> hello(string Content)
        {
            string DataResult = "";
            try
            {
                ResponseHello response = null;
               
                JObject Json = JObject.Parse(Content);
                string gpu = Json["gpu"]?.ToString();
                Json["gpu"] = "666";

                MachineHello Request_MachineHello = JsonConvert.DeserializeObject<MachineHello>(Json.ToString());
                Request_MachineHello.gpu = gpu;
                //请求数据不为空
                if (Request_MachineHello != null)
                {
                    Request_MachineHello.disk_model ??= "";
                    if (string.IsNullOrWhiteSpace(Request_MachineHello.rig_id)&&
                        Request_MachineHello.disk_model.ToUpper().Contains("UNKNOW")
                        )
                    {
                        无盘(ref response, ref DataResult, Request_MachineHello);
                    }
                   else if (string.IsNullOrWhiteSpace(Request_MachineHello.rig_id) && Request_MachineHello.farm_hash == "new")
                    {
                        FirstCreate(ref response, ref DataResult, Request_MachineHello);
                    }
                    else
                    {
                        //UpdateMachineInfo(hello)

                        
                        

                        Update(ref response, ref DataResult, Request_MachineHello);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***************************************异常**************************************");
                Console.WriteLine(ex.Message);

                Console.WriteLine("*****************************************************************************");
            }

            return Task.FromResult(DataResult);

        }
       
        private void 无盘(ref ResponseHello response, ref string DataResult, MachineHello Request_MachineHello)
        {
           //查询数据库是否存在UID
           var  hello= Db.Queryable<MachineHello>().First(s => s.uid == Request_MachineHello.uid);
            
            if (hello!=null)
            {
                Request_MachineHello.rig_id = hello.rig_id;
                Update(ref response, ref DataResult, Request_MachineHello);
            }
            else
            {

                FirstCreate(ref response, ref DataResult, Request_MachineHello);


            }


        }

        private void Update(ref ResponseHello response, ref string DataResult, MachineHello Request_MachineHello)
        {
            try
            {
                //获取hello信息
                var db_MachineHello = Db.Queryable<MachineHello>().First(s => Request_MachineHello.rig_id == s.rig_id);
                //获取MachineConfig
                var db_MachineConfig = Db.Queryable<MachineConfig>().First(s => int.Parse(Request_MachineHello.rig_id) == s.Id);
               
                //数据库找不到就创建
                if (db_MachineConfig==null|| db_MachineHello==null)
                {
                    
                    FirstCreate(ref response, ref DataResult, Request_MachineHello);
                    return;
                }
                UpdateMachineInfo(db_MachineHello, db_MachineConfig.RigName);
                TextReader textReader = new StringReader(db_MachineConfig.Wallet);


                Db.Updateable<MachineHello>(Request_MachineHello).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();



                if (Model.Config.Default.局域网加速)
                {
                    try
                    {
                        //提取路径
                        // https://code.aliyun.com/easyos/ezminer3/raw/master/gminer/gminer_2.83.tar.gz
                        string path = @"miners/" + Helper.SubstringSingle(db_MachineConfig.Wallet, "master/", "\"").Split('/')[1];
                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + path))
                        {
                            string pattern = "CUSTOM_INSTALL_URL=\"\\S+\"";
                            string url = Model.Config.Default.SERVERIP + "/" + path;
                            string result = Regex.Replace(db_MachineConfig.Wallet, pattern, "CUSTOM_INSTALL_URL=" + "\"" + url + "\"");
                            db_MachineConfig.Wallet = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        
                       
                    }

                }


                response = new ResponseHello()
                {
                    result = new()
                    {
                        amd_oc = db_MachineConfig.AmdOc,
                        autofan = db_MachineConfig.Autofan,
                        config = db_MachineConfig.Config,
                        nvidia_oc = db_MachineConfig.NvidiaOc,
                        rig_name = db_MachineConfig.RigName,
                        wallet = db_MachineConfig.Wallet,
                    }
                };




                DataResult = JsonConvert.SerializeObject(response);

                Console.WriteLine(DateTime.Now.ToString() + "成功更新或创建:\rMachineHello\rMachineStats\rMachineUserSetting\rMachineConfig\rMachineHello\r");

            }
            catch (Exception ex)
            {
                Db.RollbackTran();
                Console.WriteLine(ex.Message);
            }
        }
        private void FirstCreate(ref ResponseHello response, ref string DataResult, MachineHello Request_MachineHello,int id=0)
        {
            try
            {

                /*
                 需要创建 表:
                    1.MachineConfig
                    2.MachineHello
                    3.MachineStats
                    4.Machine_info
                    5.Machine_info2
                    6.Machine_user_setting
                 
                 */
                              
                MachineStats Insert_MachineStats=new();
                Machine_info Insert_Machine_info=new();
                Machine_info2 Insert_Machine_info2=new();
                MachineConfig Insert_MachineConfig = new();
                MachineUserSetting Insert_MachineUserSetting = new();
                MachineHello Insert_MachineHello = Request_MachineHello;

                //获取到 rig_name
                var _rig_name = $"ezos_" + (Request_MachineHello.ip.Count > 0 ? Request_MachineHello.ip[0].Split('.')[3].ToString() : "未知");
                
                //开启事务
                Db.BeginTran();
                
                //矿机名称               
                Insert_MachineConfig.RigName = _rig_name;
                Insert_MachineConfig.Addtime = DateTime.Now.ToString("G");
                if (id!=0)
                {
                    Insert_MachineConfig.Id=id;
                }
                //  插入数据 返回实体对象
                Insert_MachineConfig = Db.Insertable(Insert_MachineConfig).ExecuteReturnEntity();          
                if (Insert_MachineConfig==null)
                {
                    throw new Exception("插入MachineConfig失败!!");
                }
                

               
                Insert_MachineHello.passwd = "88888888";
                Insert_MachineHello.farm_hash = Guid.NewGuid().ToString();
                Insert_MachineHello.addtime = DateTime.Now.ToString();
                Insert_MachineHello.rig_id = Insert_MachineConfig.Id.ToString();
                if (Db.Insertable(Insert_MachineHello).ExecuteCommand()==0)
                {
                    throw new Exception("插入MachineHello失败!!");
                }


                Insert_MachineStats.rig_id = Insert_MachineConfig.Id.ToString();

                if (Db.Insertable(Insert_MachineStats).ExecuteCommand()==0)
                {
                    throw new Exception("插入MachineStats失败!!");

                }


                Insert_MachineUserSetting.rig_id = Insert_MachineConfig.Id.ToString();
                if (Db.Insertable(Insert_MachineUserSetting).ExecuteCommand() == 0)
                {
                    throw new Exception("插入MachineStats失败!!");

                }

                Insert_Machine_info.rig_id = Insert_MachineConfig.Id.ToString();
                if (Db.Insertable(Insert_Machine_info).ExecuteCommand() == 0)
                {
                    throw new Exception("插入Insert_Machine_info失败!!");

                }
                Insert_Machine_info2.rig_id = Insert_MachineConfig.Id.ToString();
                if (Db.Insertable(Insert_Machine_info2).ExecuteCommand() == 0)
                {
                    throw new Exception("插入Insert_Machine_info2失败!!");

                }


                response = GetDefaultConfig(url, Insert_MachineConfig.Id.ToString(), _rig_name, Insert_MachineHello.passwd, Insert_MachineHello.farm_hash);
                //更新
                Insert_MachineConfig.Config = response.result.config;
                Insert_MachineConfig.Wallet = response.result.wallet;
                Insert_MachineConfig.NvidiaOc = response.result.nvidia_oc;
                Insert_MachineConfig.AmdOc = response.result.amd_oc;
                Insert_MachineConfig.Autofan = response.result.autofan;
                DataResult = JsonConvert.SerializeObject(response);
                Db.Updateable(Insert_MachineConfig).ExecuteCommand();
                //事务提交
                Db.CommitTran();
                //Console.WriteLine(DateTime.Now.ToString() + "成功创建:\rMachineHello\rMachineStats\rMachineUserSetting\rMachineConfig\rMachineHello\r");

                UpdateMachineInfo(Insert_MachineHello, Insert_MachineConfig.RigName);
                Model.Config.Default.触发新增矿机事件();
            }
            catch (Exception ex)
            {   //异常回滚
                Db.RollbackTran();
                
                Console.WriteLine(ex.Message);
            }

        }
        private void UpdateMachineInfo(MachineHello hello, string RigName)
        {
            Task.Run( () => {

                try
                {
                    
                  
                    var db_machine_info = Db.Queryable<Machine_info>().First(s => s.rig_id == hello.rig_id);

                    if (db_machine_info == null)
                    {
                        throw new Exception($"在 db_machine_info 表找不到rig_id: {hello.rig_id}");

                    }
                    else
                    {
                        db_machine_info = Machine_info.GetMachine_infoFromhello(hello, RigName);
                        //更新忽略空部分
                        Db.Updateable(db_machine_info).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                GC.Collect();
                Console.WriteLine(DateTime.Now.ToString() + "完成更新 Machine_info");


            });



        }


        private static string Config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/rig.conf.txt");
        private static string Amd = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/amd-oc.conf.txt");
        private static string Nvidia = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/nvidia-oc.conf.txt");
        private static string Wallet = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/wallet.conf.txt");
        private static string Autofan = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/autofan.conf.txt");
        private static ResponseHello GetDefaultConfig(string url, string rigid, string rigname, string password, string farm_hash)
        {

            var responseHello = new ResponseHello()
            {
                result = new()
                {
                    rig_name = rigname,
                    config =Config.
                    Replace("_HIVE_HOST_URL_", url).
                    Replace("_RIG_ID_", rigid).
                    Replace("_RIG_PASSWD_", password).
                    Replace("_WORKER_NAME_", rigname).
                    Replace("_RIG_PASSWD_", password)
                    ,
                    amd_oc = Amd.
                    Replace("_core_clock_", "").
                    Replace("_core_state_", "").
                    Replace("_core_vddc_", "").
                    Replace("_core_clock_", "").
                    Replace("_mem_clock_", "").
                    Replace("_mem_state_", "").
                    Replace("_afan_", "")
                    ,
                    autofan =Autofan
                    ,
                    nvidia_oc =Nvidia.
                    Replace("_clock_", "").
                    Replace("_mem_", "").
                    Replace("_nfan_", "").
                    Replace("_plimit_", "").
                    Replace("_logo_brightness_", "").
                    Replace("_ohgodapill_enabled_", "").
                    Replace("_ohgodapill_start_timeout_", "").
                    Replace("_ohgodapill_args_", "").
                    Replace("_running_delay_", "")
                    ,
                    wallet =Wallet.
                    Replace("_minerver_name_", "gminer_2.83").
                    Replace("_minerver_addr_", "https://code.aliyun.com/easyos/ezminer3/raw/master/gminer/gminer_2.83.tar.gz").
                    Replace("_coin_name_", "eth").
                    Replace("_wallet_addr_", "0x6004A7d9Bc4D10f87822991b7D1747f40E1806bC").
                    Replace("_rig_name_", rigname).
                    Replace("_pool_addr_", "stratum+ssl://47.243.40.156:6667").
                    Replace("_user_config_", "").
                    Replace("_coin_name_", "eth")



                }
            };

            return responseHello;
        }

    }





}
