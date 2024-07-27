using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class MachineConfig
    {
        /*
         
         

        var machineConfig = new MachineConfig()
                {
                    Id = int.Parse(Model.rig_id),
                    RigName = Model.RigName,
                    Config = _Config.
                    Replace("_HIVE_HOST_URL_", Config.Default.SERVERIP).
                    Replace("_RIG_ID_", Model.rig_id).
                    Replace("_RIG_PASSWD_", "88888888").
                    Replace("_WORKER_NAME_", Model.RigName)

                    ,
                    AmdOc = _Amd.
                        Replace("_core_clock_", Model.CoreClock).
                        Replace("_core_state_", Model.CoreState).
                        Replace("_core_vddc_", Model.CoreVddc).
                        Replace("_mem_clock_", Model.MemClock).
                        Replace("_mem_state_", Model.MemState).
                        Replace("_afan_", Model.Afan)
                        //,
                        //Autofan = _Autofan
                        ,
                    NvidiaOc = _Nvidia.
                        Replace("_clock_", Model.Clock).
                        Replace("_mem_", Model.Mem).
                        Replace("_nfan_", Model.Nfan).
                        Replace("_plimit_", Model.Plimit).
                        Replace("_logo_brightness_", Model.LogoBrightness).
                        Replace("_ohgodapill_enabled_", Model.OhgodapillEnabled?.ToString()).
                        Replace("_ohgodapill_start_timeout_", Model.OhgodapillStartTimeout?.ToString()).
                        Replace("_ohgodapill_args_", Model.OhgodapillArgs?.ToString()).
                        Replace("_running_delay_", Model.RunningDelay?.ToString())
                    ,

                    Wallet = _Wallet.
                    Replace("_minerver_name_", SelectMining.MinerverName).
                    Replace("_minerver_addr_", 核心下载地址).
                    Replace("_coin_name_", SelectMining.CoinName).
                    Replace("_wallet_addr_", SelectMining.WalletAddr).
                    Replace("_rig_id_", Model.rig_id).
                    Replace("_rig_name_", Model.RigName).
                    Replace("_pool_addr_", SelectMining.PoolAddr).
                    Replace("_user_config_", SelectMining.UserConfig)
                    , Autofan = _Autofan,
                    Addtime = DateTime.Now.ToString("g")
              };

         */

        private static string _Config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/rig.conf.txt");
        private static string _Amd = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/amd-oc.conf.txt");
        private static string _Nvidia = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/nvidia-oc.conf.txt");
        private static string _Wallet = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/wallet.conf.txt");
        private static string _Autofan = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/autofan.conf.txt");
        public static string GetRigconfTemplate(string HIVE_HOST_URL, string RIG_ID, string WORKER_NAME, string RIG_PASSWD = "\"88888888\"")
        {

            return  _Config.
                    Replace("_HIVE_HOST_URL_", HIVE_HOST_URL).
                    Replace("_RIG_ID_", RIG_ID).
                    Replace("_RIG_PASSWD_", RIG_PASSWD).
                    Replace("_WORKER_NAME_", WORKER_NAME);
        }
        public static string GetWalletTemplate(Mining _mining,string rig_id, string rig_name)
        {

            return _Wallet.
                    Replace("_minerver_name_", _mining.挖矿软件名称).//核心名称
                    Replace("_minerver_addr_", _mining.MinerverAddr).//核心下载地址
                    Replace("_coin_name_", _mining.CoinName).//币种名称
                    Replace("_wallet_addr_", _mining.WalletAddr).//钱包地址
                    Replace("_rig_id_", rig_id).//主机id
                    Replace("_rig_name_", rig_name).//主机名
                    Replace("_pool_addr_", _mining.PoolAddr).//矿池地址
 //                   Replace("_password_", String.IsNullOrWhiteSpace(_mining.password)?"88888888": _mining.password).//密码;
                    Replace("_password_", _mining.password).//密码;
                    Replace("_user_config_", _mining.UserConfig??"");//用户配置;

        }
        public static string GetAutoFanTemplate()
        {
           
            return _Autofan;
        }
        public static string GetAmd_ocTemplate(MachineUserSetting oc )
        {
         
            return _Amd.
                        Replace("_core_clock_", oc.CoreClock).
                        Replace("_core_state_", oc.CoreState).
                        Replace("_core_vddc_", oc.CoreVddc).
                        Replace("_mem_clock_", oc.MemClock).
                        Replace("_mem_state_", oc.MemState).
                        Replace("_afan_", oc.Afan);
            
        }
        public static string GetNvidia_ocTemplate(MachineUserSetting oc)
        {

            return _Nvidia.
                        Replace("_clock_", oc.Clock??"").
                        Replace("_mem_", oc.Mem??"").
                        Replace("_nfan_", oc.Nfan??"").
                        Replace("_plimit_", oc.Plimit??"").
                        Replace("_logo_brightness_", oc.LogoBrightness??"").
                        Replace("_ohgodapill_enabled_", oc.OhgodapillEnabled?.ToString()??"").
                        Replace("_ohgodapill_start_timeout_", oc.OhgodapillStartTimeout?.ToString()??"").
                        Replace("_ohgodapill_args_", oc.OhgodapillArgs?.ToString()??"").
                        Replace("_running_delay_", oc.RunningDelay?.ToString()??"");


        }
    }
}
