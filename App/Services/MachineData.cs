using DB.IService;
using Model;
using Model.Configtemplate;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DB.service
{
    /// <summary>
    /// 矿机列表数据库访问服务
    /// </summary>
    public class MachineData : IMachineData
    {
        private SqlSugarScope _db;
        public MachineData(SqlSugarScope Db)
        {
                _db = Db;
          
        }

        /// <summary>
        /// 批量添加命令
        /// </summary>
        /// <param name="updateList">机器列表</param>
        /// <param name="shell">命令代码</param>
        /// <returns></returns>
        public bool AddCommand(List<Machine_info> updateList, string shell)
        {
            try
            {
                //从数据库查找命令码
                var cmd =  _db.Queryable<Model.Action>().First(c => c.ActionName == shell)?.Shell;
                //命令码为空是 shell用于做命令码
                if (cmd == null)cmd = shell;
                //创建一个命令列表
                List<TaskList> list = new();
                foreach (var item in updateList)
                {
                    //添加命令信息
                    list.Add(new()
                    {
                        Addtime = DateTime.Now,
                        Passwd = "88888888",
                        RigId = item.rig_id,
                        Shell = cmd
                    });
                }
                ///保存到数据库
                 _db.Insertable(list).ExecuteCommand();
                this.LogINFO($"添加命令:{cmd} 成功");
               
            }
            catch(Exception ex)
            {
                this.LogException(ex);
                //异常则抛出
                throw;
            }
            return true;
        }

        /// <summary>
        /// 删除矿机
        /// </summary>
        /// <param name="delectList">删除列表</param>
        /// <returns></returns>
        public bool Delete(List<Machine_info> delectList)
        {
            try
            {
                //获取所有要删除矿机的id
                var arr_rigid = delectList.Select(s => s.rig_id).ToArray();

                //开启事务
                _db.BeginTran();
                //删除包含的id
                _db.Deleteable<MachineConfig>().Where(s => arr_rigid.Contains(s.Id.ToString())).ExecuteCommand();
                _db.Deleteable<MachineHello>().Where(s => arr_rigid.Contains(s.rig_id.ToString())).ExecuteCommand();
                _db.Deleteable<MachineStats>().Where(s => arr_rigid.Contains(s.rig_id.ToString())).ExecuteCommand();
                _db.Deleteable<MachineUserSetting>().Where(s => arr_rigid.Contains(s.rig_id.ToString())).ExecuteCommand();
                _db.Deleteable<Machine_info>().Where(s => arr_rigid.Contains(s.rig_id.ToString())).ExecuteCommand();
                _db.Deleteable<Machine_info2>().Where(s => arr_rigid.Contains(s.rig_id.ToString())).ExecuteCommand();
                _db.Deleteable<TaskList>().Where(s => arr_rigid.Contains(s.RigId.ToString())).ExecuteCommand();
                _db.Deleteable<TaskDone>().Where(s => arr_rigid.Contains(s.RigId.ToString())).ExecuteCommand();
                //提交事务
                _db.CommitTran();
                this.LogINFO("移除机器成功");
              
            }
            catch(Exception ex) 
            {
                
                //异常回滚
                _db.RollbackTran();
                this.LogException(ex, "移除机器出现异常");
                throw;
            }
            return true;
        }

        public string GetAllTotal()
        {
           var arr= _db.Queryable<Machine_info>().Where(s=>s.状态=="在线").Select(it=>it.算力).ToArray();
            //arr[i]=22.5 MHS
            double total=0;
            double total2 = 0;
            string returntext = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                   var 算力s= arr[i]?.ToUpper().Split("|");
                    if (算力s==null)
                    {

                    }
                    else
                    {
                        var xx = 算力s[0].Split(" ");

                        if (xx != null && xx.Length == 2)
                        {

                            switch (xx[1])
                            {
                                case "KHS": total += double.Parse(xx[0]) * Math.Pow(1000, 0); break;
                                case "MHS": total += double.Parse(xx[0]) * Math.Pow(1000, 1); break;
                                case "GHS": total += double.Parse(xx[0]) * Math.Pow(1000, 2); break;
                                case "THS": total += double.Parse(xx[0]) * Math.Pow(1000, 3); break;
                                case "PHS": total += double.Parse(xx[0]) * Math.Pow(1000, 4); break;
                                default:
                                    throw new Exception("格式异常:" + xx[1]);
                            }


                        }
                        else
                        {
                            throw new Exception("数据是不正常的!xx.Length==" + xx.Length);
                        }

                        if (算力s.Length == 2)
                        {
                            var xx2 = 算力s[1].Split(" ");

                            if (xx2 != null && xx2.Length == 2)
                            {

                                switch (xx2[1])
                                {
                                    case "KHS": total2 += double.Parse(xx2[0]) * Math.Pow(1000, 0); break;
                                    case "MHS": total2 += double.Parse(xx2[0]) * Math.Pow(1000, 1); break;
                                    case "GHS": total2 += double.Parse(xx2[0]) * Math.Pow(1000, 2); break;
                                    case "THS": total2 += double.Parse(xx2[0]) * Math.Pow(1000, 3); break;
                                    case "PHS": total2 += double.Parse(xx2[0]) * Math.Pow(1000, 4); break;
                                    default:
                                        throw new Exception("格式异常:" + xx2[1]);
                                }


                            }
                            else
                            {
                                throw new Exception("数据是不正常的!xx.Length==" + xx2.Length);
                            }
                        }

                    }

                }



                

             
                int n = (((long)total).ToString().Length - 1) / 3;
                switch (n)
                {
                    case 1:
                        returntext = String.Format("{0:0.0} Mhs", total / Math.Pow(1000, 1));
                        break;
                    case 2:
                        returntext = String.Format("{0:0.0} Ghs", total / Math.Pow(1000, 2)); break;
                    case 3:
                        returntext = String.Format("{0:0.0} Ths", total / Math.Pow(1000, 3)); break;
                    case 4:
                        returntext = String.Format("{0:0.0} Phs", total / Math.Pow(1000, 4)); break;
                    default:
                        returntext = total + " Khs"; break;
                }


                if (total2!=0)
                {

                    long data2 = (long)total2;
                   
                    int n2 = (total2.ToString().Length - 1) / 3;
                    switch (n2)
                    {
                        case 1:
                            returntext += "|" + String.Format("{0:0.0} Mhs", data2 / Math.Pow(1000, 1));
                            break;
                        case 2:
                            returntext += "|" + String.Format("{0:0.0} Ghs", data2 / Math.Pow(1000, 2)); break;
                        case 3:
                            returntext += "|" + String.Format("{0:0.0} Ths", data2 / Math.Pow(1000, 3)); break;
                        case 4:
                            returntext += "|" + String.Format("{0:0.0} Phs", data2 / Math.Pow(1000, 4)); break;
                        default:
                            returntext += "|" + data2 + " Khs"; break;
                    }



                }

            }
            catch (Exception ex)
            {

                this.LogException(ex);
            }


            return returntext;
        }

        /// <summary>
        /// 返回矿机数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {   
            return _db.Queryable<Machine_info>().Count();
        }
        /// <summary>
        /// 返回异常数量
        /// </summary>
        /// <returns></returns>
        public int GetErrorCount()
        {

            return _db.Queryable<Machine_info>().Where(s => s.状态 == "在线" && (s.算力 == "0 Khs" ||string.IsNullOrEmpty(s.算力))).Count(); ;
        }
        /// <summary>
        /// 获取矿机列表
        /// </summary>
        /// <returns></returns>
        public List<Machine_info> GetList()
        {
          return _db.Queryable<Machine_info>().ToList();
        }
        /// <summary>
        /// 查询矿机列表 模糊查询
        /// </summary>
        /// <param name="QueryContent"></param>
        /// <returns></returns>
        public List<Machine_info> GetList(string QueryContent)
        {
            
            return _db.Queryable<Machine_info>().Where(s =>
               s.状态.Contains(QueryContent) ||
               //s.主机名.Contains(QueryContent) ||
               //s.算力.Contains(QueryContent) ||
               //s.接受率.Contains(QueryContent) ||
               //s.最高温度.Contains(QueryContent) ||
               //s.挖矿时长.Contains(QueryContent) ||
               s.显卡.Contains(QueryContent) ||
               //  s.模板.Contains(QueryContent) ||
               s.IP.Contains(QueryContent)
               //  s.备注.Contains(QueryContent)
               ).ToList();
        }

        /// <summary>
        /// 获取离线数量
        /// </summary>
        /// <returns></returns>
        public int GetOfflineCount()
        {
           return _db.Queryable<Machine_info>().Count(s => s.状态 != "在线");
        }
        /// <summary>
        /// 获取在线数量
        /// </summary>
        /// <returns></returns>
        public int GetONlineCount()
        {
            return _db.Queryable<Machine_info>().Count(s => s.状态 == "在线");
        }

        /// <summary>
        /// 更新挖矿模板
        /// </summary>
        /// <param name="mchineList"></param>
        /// <param name="mining"></param>
        /// <returns></returns>
        public bool UpdateMinng(List<Machine_info> mchineList,Mining mining)
        {

            try
            {
                //选中的数量
                string[] arr_rigid = mchineList.Select(s => s.rig_id).ToArray();

                //获取 挖矿模板信息
                var _db_mining =   _db.Queryable<Mining>().First (s => s.Id == mining.Id);
                //获取选中的
                var _db_machineinfo =   _db.Queryable<Machine_info>().Where(s => arr_rigid.Contains(s.rig_id)).ToList ();

                var _db_machineinfo2 = _db.Queryable<Machine_info2>().Where(s => arr_rigid.Contains(s.rig_id)).ToList();
                //获取选中的
                var _db_machineStats =   _db.Queryable<MachineStats>().Where(s => arr_rigid.Contains(s.rig_id)).ToList ();
                //获取选中的用户配置信息
                var _db_machineUserSetting =   _db.Queryable<MachineUserSetting>().Where(s => arr_rigid.Contains(s.rig_id)).ToList ();

                //更改 显示模板  挖矿模板名
                foreach (var item in _db_machineinfo) item.模板 = mining.MiningName;
                foreach (var item in _db_machineinfo2) { item.挖矿模板 = mining.MiningName;}
                //更改 用户设置选中的  挖矿模板id
                foreach (var item in _db_machineUserSetting) item.MiningId = mining.Id.ToString();


                //创建  MachineConfig 列表对象
                List<MachineConfig> MachineConfiglist = new List<MachineConfig>();
                //修改 MachineConfig对象信息 
                foreach (var item in _db_machineUserSetting)
                {
                    MachineConfiglist.Add(new()
                    {
                        Id = int.Parse(item.rig_id),
                        Config =
                        MachineConfig.GetRigconfTemplate(Model.Config.Default.SERVERIP, item.rig_id,
                        item.RigName,_db_mining.password)
                
                    ,

                        Wallet = MachineConfig.GetWalletTemplate(mining, item.rig_id, item.RigName)
                       


                    });
                }
                //开启事务
                _db.Ado.BeginTran();
                //更新 Machine_info 到数据库 只更新 模板 一列
                var result0 = _db.Updateable(_db_machineinfo).UpdateColumns(it => new { it.模板 }).ExecuteCommand();
                var result4 = _db.Updateable(_db_machineinfo2).UpdateColumns(it => new { it.主机名,it.挖矿模板 }).ExecuteCommand();
                //更新 machineUserSetting 到数据库 只更新 MiningId 一列
                var result1 = _db.Updateable(_db_machineUserSetting).UpdateColumns(it => new { it.MiningId }).ExecuteCommand();
                //更新 MachineConfig 到数据库 只更新 Wallet和 Config 列
                var result2 = _db.Updateable(MachineConfiglist).UpdateColumns(it => new { it.Wallet, it.Config, }).ExecuteCommand();
               
                //提交事务
                _db.Ado.CommitTran();


            }
            catch 
            {
                _db.Ado.RollbackTran();
                throw;

            }

            return true;


        }
        /// <summary>
        /// 更新超频模板
        /// </summary>
        /// <param name="updateList"></param>
        /// <param name="overclocking"></param>
        /// <returns></returns>
        public bool UpdateOverclocking(List<Machine_info> updateList, Overclocking overclocking )
        {
            try
            {
                //获取所有的id
                string[] allIds = updateList.Select(s=>s.rig_id).ToArray();
                //获取返回的所有 MachineUserSetting
                var machineUserSetting =  _db.Queryable<MachineUserSetting>().Where(s => allIds.Contains(s.rig_id)).ToList();

                
                foreach (var item in machineUserSetting)
                {
                    item.Clock = overclocking.Clock;
                    item.Mem = overclocking.Mem;
                    item.Plimit = overclocking.Plimit;
                    item.Nfan = overclocking.Nfan;
                    item.CoreClock = overclocking.CoreClock;
                    item.CoreState = overclocking.CoreState;
                    item.CoreVddc = overclocking.CoreVddc;
                    item.MemClock = overclocking.MemClock;
                    item.Afan = overclocking.Afan;
                    

                    // item.MiningId = 选中Overclocking;
                }

                List<MachineConfig> MachineConfiglist = new List<MachineConfig>();

                foreach (var item in machineUserSetting)
                {
                    MachineConfiglist.Add(new()
                    {
                        Id = int.Parse(item.rig_id),
                        AmdOc =ConfigTemplate.Amd.
                        Replace("_core_clock_", item.CoreClock).
                        Replace("_core_state_", item.CoreState).
                        Replace("_core_vddc_", item.CoreVddc).
                        Replace("_mem_clock_", item.MemClock).
                        Replace("_mem_state_", item.MemState).
                        Replace("_afan_", item.Afan)
                        //,
                        //Autofan = _Autofan
                        ,
                        NvidiaOc = ConfigTemplate.Nvidia.
                        Replace("_clock_", item.Clock).
                        Replace("_mem_", item.Mem).
                        Replace("_nfan_", item.Nfan).
                        Replace("_plimit_", item.Plimit).
                        Replace("_logo_brightness_", item.LogoBrightness).
                        Replace("_ohgodapill_enabled_", item.OhgodapillEnabled?.ToString()).
                        Replace("_ohgodapill_start_timeout_", item.OhgodapillStartTimeout?.ToString()).
                        Replace("_ohgodapill_args_", item.OhgodapillArgs?.ToString()).
                        Replace("_running_delay_", item.RunningDelay?.ToString())
                    });
                }
                _db.Ado.BeginTran();
                var result1 = _db.Updateable(machineUserSetting).UpdateColumns(
                    it => new {
                        it.Clock,
                        it.Mem,
                        it.Plimit,
                        it.Nfan,
                        it.CoreClock,
                        it.CoreState,
                        it.CoreVddc,
                        it.MemClock,
                        it.Afan,

                    }).ExecuteCommand();
                var result2 = _db.Updateable(MachineConfiglist).UpdateColumns(it => new { it.AmdOc, it.Autofan, it.NvidiaOc }).ExecuteCommand();
                _db.Ado.CommitTran();
             
            
            }
            catch 
            {
                _db.Ado.RollbackTran();
                throw;
            }
            return true;
        }
    }
}