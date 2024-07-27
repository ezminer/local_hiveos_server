using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Machine_info2
    {

        public static Machine_info2 GetMachine_info(MachineHello hello, MachineStats stats,string rig_name)
        {
            if (hello == null || stats == null) throw new Exception("hello == null || stats == null");
            
            var model = new Machine_info2();
            try
            {
                model.显卡信息 = new();
                model.主机名 = rig_name;
                model.rig_id = hello.rig_id;
                model.总功耗 = Get总功耗(stats);
                model.总算力 = Get总算力(stats);
                
                model.挖矿时长 = Get挖矿时长(stats);
                model.币种 = Get币种(stats);
                model.拒绝 = Get拒绝(stats);
                model.无效 = Get无效(stats);
                model.核心版本 = Get核心版本(stats);
                model.算法 = Get算法(stats);
                model.有效 = Get有效(stats);
                model.有效率 = Get有效率(stats);
                model.挖矿模板 = "";
                model.A卡驱动 = GetA卡驱动(hello);
                model.N卡驱动 = GetN卡驱动(hello);
                model.内网IP = Get内网IP(hello);
                model.外网IP = "";
                model.cpu使用率 = GetCpu使用率(stats);
                model.cpu型号 = GetCpu型号(hello);
                model.CPU核心数 = GetCPU核心数(hello);
                model.固件版本 = Get固件版本(hello);
                model.Mac地址 = GetMac地址(hello);
                model.主板厂家 = Get主板厂家(hello);
                model.主板型号 = Get主板型号(hello);
                model.内存大小 = Get内存大小(stats);
                model.可用内存 = Get可用内存(stats);
                model.在线时长 = Get在线时长(hello);
                model.本地磁盘 = Get本地磁盘(hello);
                model.延迟= Get延迟(stats);
                model.内核版本=Get内核版本号(hello);
               
                Set显卡信息(hello,stats, model);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(DateTime.Now.ToString() +ex.Message);
            }
               
        
      




            //显卡数量 以算力 做数量

          

            return model;
            static string Get内网IP(MachineHello hello)
            {

                return hello.ip?.FirstOrDefault();
            }
            static string GetCpu使用率(MachineStats stats)
            {
                if (stats.cpuavg == null) return "";
                
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("[");
                foreach (var item in stats.cpuavg)
                {
                    stringBuilder.Append($"{item} ,");
                }
                stringBuilder.Append("]  ");
                stringBuilder.Append(stats.cputemp.First()??"");
                return stringBuilder.ToString();
            }
            static string GetCpu型号(MachineHello hello)
            {

                return hello.cpu?.model;
            }
            static string GetCPU核心数(MachineHello hello)
            {

                return hello.cpu?.cores;
            }
            static string Get固件版本(MachineHello hello)
            {

                return hello.version;
            }
            static string Get主板厂家(MachineHello hello)
            {
                if (hello.mb != null)
                {
                    return hello.mb.manufacturer;
                }
                return "未知";
            }
            static string Get主板型号(MachineHello hello)
            {
                if (hello.mb != null)
                {
                    return hello.mb.product;
                }
                return "未知";
            }
            static string Get内核版本号(MachineHello hello)
            {
                if (hello.mb != null)
                {
                    return hello.kernel;
                }
                return "未知";
            }
            static string Get本地磁盘(MachineHello hello)
            {

                return hello.disk_model;
            }

            static string Get内存大小(MachineStats stats)
            {
                if (stats.mem != null)
                {
                    return stats.mem.FirstOrDefault() + "Mb";
                }
                return "未知";
            }
            static string Get可用内存(MachineStats stats)
            {
                if (stats.mem != null && stats.mem.Count >= 2)
                {

                    return stats.mem[1] + "Mb";
                }
                return "未知";
            }
            static string Get延迟(MachineStats stats)
            {
                if (stats.miner_stats != null && stats.miner_stats.yanchi!=null)
                {

                    return stats.miner_stats.yanchi;
                }
                return "未知";
            }
           

            static string GetMac地址(MachineHello hello)
            {
                if (hello.net_interfaces != null)
                {

                    return hello.net_interfaces.FirstOrDefault()?.mac;

                }
                return "未知";
            }
            static string GetA卡驱动(MachineHello hello)
            {

                return hello.amd_version;
            }
            static string GetN卡驱动(MachineHello hello)
            {

                return hello.nvidia_version;
            }
            static string Get有效(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.miner_stats != null && stats.miner_stats.ar != null)
                {
                    if (stats.miner_stats.ar.Count >= 1)
                    {
                        returntext = stats.miner_stats.ar[1];
                    }


                }
                return returntext;
            }
            static string Get无效(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.miner_stats != null && stats.miner_stats.ar != null)
                {
                    if (stats.miner_stats.ar.Count >= 2)
                    {
                        returntext = stats.miner_stats.ar[2];
                    }


                }
                return returntext;
            }
            static string Get拒绝(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.miner_stats != null && stats.miner_stats.ar != null)
                {
                    if (stats.miner_stats.ar.Count >= 3)
                    {
                        returntext = stats.miner_stats.ar[3];
                    }


                }
                return returntext;
            }
            static string Get挖矿时长(MachineStats stats)
            {
                var onlineTime = "00:00:00";
                if (stats.miner_stats != null)
                {
                    try
                    {
                        var h = (stats.miner_stats.uptime / (60 * 60));
                        var m = (stats.miner_stats.uptime % (60 * 60)) / 60;
                        onlineTime = String.Format("{0:00}时{1:00}分", h, m);

                    }
                    catch (Exception)
                    {
                    }
                }

                return onlineTime;
            }
            static string Get在线时长(MachineHello hello)
            {
                
                try
                {
                    if (string.IsNullOrEmpty(hello.boot_time))
                    {
                        return "";

                    }
                    long i = 0;
                    
                    long.TryParse(hello.boot_time, out i);
                    if (i == 0)
                    {
                        return "";
                    }
                    else
                    {
                        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区
                                                                                                                          //
                        var time = DateTime.Now - startTime.AddSeconds(i);


                        return String.Format("{0:00}时{1:00}分", time.Hours + time.Days * 24, time.Minutes);
                    }
               

                }
                catch (Exception)
                {


                }




                return "";
            }
            static string Get有效率(MachineStats stats)
            {
                string jieshoulv = "00%";
                try
                {
                    if (stats.miner_stats != null&& stats.miner_stats.ar!=null)
                    {
                        List<int> intlist = new List<int>();

                        foreach (var item in stats.miner_stats.ar)
                        {
                            var i = 0;
                            int.TryParse(item, out i);
                            intlist.Add(i);
                        }
                        int count = 0;
                        foreach (var item in intlist)
                        {
                            count += item;
                        }
                        if (count == 0)
                        {
                            jieshoulv = "00%";
                        }
                        else
                        {
                            jieshoulv = String.Format("{0:00}%", (intlist[0] * 100.0 / count));
                        }
                    }


                }
                catch (Exception)
                {


                }

                return jieshoulv;
            }
           
            static string Get算法(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.miner_stats != null)
                {

                    returntext = stats.miner_stats.algo;

                }
                return returntext;
            }
            static string Get币种(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.meta != null)
                {
                    if (stats.meta.custom != null)
                    {
                        returntext = stats.meta.custom.coin;
                    }
                }
                return returntext;
            }
            static string Get核心版本(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.miner_stats != null)
                {

                    returntext = stats.miner_stats.ver;

                }
                return returntext;
            }
            static string Get总功耗(MachineStats stats)
            {
                var returntext = "未知";
                if (stats.power != null)
                {
                    var num = 0;
                    foreach (string item in stats.power)
                    {
                        var i = 0;

                      int.TryParse(item, out i);
                        num+=i;

                    }
                    returntext = num.ToString()+"W";

                }
                return returntext;
            }
            static string Get总算力(MachineStats stats)
            {
                string returntext = "";
                
                long data = 0;
                long.TryParse(stats.total_khs,out data);
                int n = (stats.total_khs.Length - 1) / 3;
                switch (n)
                {
                    case 1:
                        returntext = String.Format("{0:0.0} Mhs", data / Math.Pow(1000, 1));
                        break;
                    case 2:
                        returntext = String.Format("{0:0.0} Ghs", data / Math.Pow(1000, 2)); break;
                    case 3:
                        returntext = String.Format("{0:0.0} Ths", data / Math.Pow(1000, 3)); break;
                    case 4:
                        returntext = String.Format("{0:0.0} Phs", data / Math.Pow(1000, 4)); break;
                    default:
                        returntext = stats.total_khs + " Khs"; break;
                }

              
                if (stats.miner_stats?.total_khs2 != null)
                {
                  
                    long data2 = 0;
                    long.TryParse(stats.miner_stats?.total_khs2, out data2);
                    int n2 = (data2.ToString().Length - 1) / 3;
                    switch (n2)
                    {
                        case 1:
                            returntext +="|"+ String.Format("{0:0.0} Mhs", data2 / Math.Pow(1000, 1));
                            break;
                        case 2:
                            returntext += "|" + String.Format("{0:0.0} Ghs", data2 / Math.Pow(1000, 2)); break;
                        case 3:
                            returntext += "|" + String.Format("{0:0.0} Ths", data2 / Math.Pow(1000, 3)); break;
                        case 4:
                            returntext+= "|" + String.Format("{0:0.0} Phs", data2 / Math.Pow(1000, 4)); break;
                        default:
                            returntext += "|" + stats.total_khs + " Khs"; break;
                    }



                }

                return returntext;
            }
            static void Set单卡拒绝(MachineStats stats, Machine_info2 model)
            {
                if (stats.miner_stats != null && stats.miner_stats.ar != null)
                {
                    if (stats.miner_stats.ar.Count >= 4)
                    {
                        string[] strArr = stats.miner_stats.ar[3].Trim().Split(';');
                        if (strArr.Length-1 == model.显卡信息.Count)
                        {
                            for (int i = 0; i < model.显卡信息.Count; i++)
                            {
                                model.显卡信息[i].单卡拒绝 = strArr[i];
                            }
                        }
                        else
                        {
                            
                        }



                    }

                }
            }

            static void Set算力(MachineStats stats, Machine_info2 model)
            {

                if (stats.miner_stats != null&& stats.miner_stats.hs!=null&& stats.miner_stats.hs.Count==model.显卡信息.Count)
                {
                    int Count = stats.miner_stats.hs.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        long data = 0;
                        long.TryParse(stats.miner_stats.hs[i], out data);
                        int n = (stats.total_khs.Length - 1) / 3;
                        switch (n)
                        {
                            case 1:
                                model.显卡信息[i].算力 = String.Format("{0:0.0} Mhs", data / Math.Pow(1000, 1));
                                break;
                            case 2:
                                model.显卡信息[i].算力 = String.Format("{0:0.0} Ghs", data / Math.Pow(1000, 2)); break;
                            case 3:
                                model.显卡信息[i].算力 = String.Format("{0:0.0} Ths", data / Math.Pow(1000, 3)); break;
                            case 4:
                                model.显卡信息[i].算力 = String.Format("{0:0.0} Phs", data / Math.Pow(1000, 4)); break;
                            default:
                                model.显卡信息[i].算力 = stats.total_khs + " Khs"; break;
                        }


                    }
                }
                if (stats.miner_stats != null && stats.miner_stats.hs2 != null && stats.miner_stats.hs2.Count == model.显卡信息.Count)
                {

                    int Count = stats.miner_stats.hs2.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        long data = 0;
                        long.TryParse(stats.miner_stats.hs2[i].Split(".")[0], out data);
                        data *= 1000;
                        int n = (stats.total_khs.Length - 1) / 3;
                        switch (n)
                        {
                            case 1:
                                model.显卡信息[i].算力 += "||"+String.Format("{0:0.0} Mhs", data / Math.Pow(1000, 1));
                                break;
                            case 2:
                                model.显卡信息[i].算力 += "||" + String.Format("{0:0.0} Ghs", data / Math.Pow(1000, 2)); break;
                            case 3:
                                model.显卡信息[i].算力 += "||" + String.Format("{0:0.0} Ths", data / Math.Pow(1000, 3)); break;
                            case 4:
                                model.显卡信息[i].算力 += "||" + String.Format("{0:0.0} Phs", data / Math.Pow(1000, 4)); break;
                            default:
                                model.显卡信息[i].算力 += "||" + stats.total_khs + " Khs"; break;
                        }


                    }

                }


               
            }
            static void Set风扇(MachineStats stats, Machine_info2 model)
            {
                if (stats.miner_stats != null && stats.miner_stats.fan != null)
                {
                    if (stats.miner_stats.fan.Count == model.显卡信息.Count)
                    {
                        for (int i = 0; i < model.显卡信息.Count; i++)
                        {
                            model.显卡信息[i].风扇 = stats.miner_stats.fan[i]+" %";
                        }

                    }
                    

                }
                //else if (stats.fan != null && stats.fan.Count >= model.显卡信息.Count)
                //{
                //    for (int i = 0; i < model.显卡信息.Count; i++)
                //    {
                //        model.显卡信息[i].显卡温度 = stats.fan[i];
                //    }
                //}
            }
            static void Set温度(MachineStats stats, Machine_info2 model)
            {
                if (stats.miner_stats != null && stats.miner_stats.temp != null)
                {
                    if (stats.miner_stats.temp.Count == model.显卡信息.Count)
                    {
                        for (int i = 0; i < model.显卡信息.Count; i++)
                        {
                            model.显卡信息[i].显卡温度 = stats.miner_stats.temp[i]+"°C";
                        }

                    }
                    //else if (stats.temp != null && stats.temp.Count >= model.显卡信息.Count)
                    //{
                    //    for (int i = 0; i < model.显卡信息.Count; i++)
                    //    {
                    //        model.显卡信息[i].显卡温度 = stats.temp[i] + "°C";
                    //    }
                    //}

                }
            }
            static void Set显存温度(MachineStats stats, Machine_info2 model)
            {
                if (stats.miner_stats != null && stats.miner_stats.mtemp != null)
                {
                    try
                    {
                        if (stats.miner_stats.mtemp.Count == model.显卡信息.Count)
                        {
                            for (int i = 0; i < model.显卡信息.Count; i++)
                            {
                                model.显卡信息[i].显存温度 = stats.miner_stats.mtemp[i] + "°C"; ;
                            }

                        }
                    }
                    catch (Exception)
                    {

                       
                    }
                  

                }
            }
            static void Set功耗(MachineStats stats, Machine_info2 model)
            {
                if (stats != null && stats.power != null)
                {
                    if (stats.power.Count >= model.显卡信息.Count)
                    {
                        if(stats.power.Count - 1 == model.显卡信息.Count)stats.power.RemoveAt(0);


                         if (stats.power.Count== model.显卡信息.Count)
                        {
                            for (int i = 0; i < model.显卡信息.Count; i++)
                            {

                                model.显卡信息[i].实时功耗 = stats.power[i] + " W";
                            }
                        }
                        
                        }


                    }
                   

                
            }
            static void Set显卡信息(MachineHello hello, MachineStats stats, Machine_info2 model)
            {
                if (hello.gpu != null)
                {

                    //GPU列表
                    var Gpus = JArray.Parse(hello.gpu);
                    //移除集显
                    try
                    {
                        var it = Gpus.Where(s=>s["brand"]?.ToString().ToLower() == "cpu").ToList();
                        foreach (var item in it)
                        {
                            Gpus.Remove(item);
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        
                       
                    }

                    foreach (var item in Gpus)
                    {
                        var _显卡信息 = new 显卡信息()
                        { 
                            品牌 = item["subvendor"]?.ToString()??"",
                            显卡型号 = item["name"]?.ToString() ?? "",
                            默认功耗 = item["plim_def"]?.ToString() ?? "",
                            颗粒 = item["mem_type"]?.ToString() ?? "",
                            最小功耗 = item["plim_min"]?.ToString() ?? "",
                            显存大小 = item["mem"]?.ToString() ?? "",
                            单卡拒绝 = "",
                            实时功耗 = "",
                            显卡温度 = "",
                            显存温度 = "",
                            算力     = "",
                            风扇     = "",

                        };

                        model.显卡信息.Add(_显卡信息);


                     
                    }


                    Set算力(stats, model);
                    Set风扇(stats, model);
                    Set温度(stats, model);
                    Set显存温度(stats, model);
                    Set功耗(stats, model);
                    Set单卡拒绝(stats, model);




                }
            }
            static void Set显卡信息2(MachineHello hello, Machine_info2 model)
            {
                if (hello.gpu != null)
                {
                    var Gpus = JArray.Parse(hello.gpu);
                    if (model.显卡信息.Count == Gpus.Count)
                    {
                        for (int i = 0; i < model.显卡信息.Count; i++)
                        {
                            try
                            {
                                if (Gpus[i]["brand"]?.ToString().ToLower() == "cpu")
                                {
                                    model.显卡信息.Remove(model.显卡信息.Last());
                                    continue;

                                }
                                model.显卡信息[i].品牌 = Gpus[i]["brand"]?.ToString();
                                model.显卡信息[i].显卡型号 = Gpus[i]["name"]?.ToString();
                                model.显卡信息[i].默认功耗 = Gpus[i]["plim_def"]?.ToString();
                                model.显卡信息[i].颗粒 = Gpus[i]["mem_type"]?.ToString();
                                model.显卡信息[i].最小功耗 = Gpus[i]["plim_min"]?.ToString();
                                model.显卡信息[i].显存大小 = Gpus[i]["mem"]?.ToString();

                            }
                            catch (Exception)
                            {


                            }
                        }

                    }
                }
            }


           

        }

      


    }
}
