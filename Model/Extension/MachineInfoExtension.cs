using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Machine_info :INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Machine_info GetMachine_infoFromStats( MachineStats stats)
        {

            var model = new Machine_info();
            model.rig_id = stats.rig_id;
           //model.主机名 = "";// showlist.RigName;
            model.状态 = "在线";// showlist.OnOff;
            model.算力 = Get总算力(stats);
            model.接受率 = Get接受率(stats); ;
            model.温度 = Get温度(stats);
            model.挖矿时长 = Get挖矿时长(stats);
            //model.显卡 = Get显卡(hello); ;
            //model.模板 = stats.Mining;
            //model.IP = stats.;
            //model.备注 = showlist.Other;
            return model;

            static string Get接受率(MachineStats stats)
            {
                string jieshoulv = "00%";
                try
                {
                    if (stats.miner_stats!=null&& stats.miner_stats.ar!=null)
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

            static string Get温度(MachineStats stats)
            {
                return stats.temp.Max()+"°C";
            }
            static string Get算力(MachineStats stats)
            {
                //stats.total_khs = "9910000";//1000 000
                long data = 0;
                long.TryParse( stats.total_khs,out data);
                int n = (stats.total_khs.Length - 1) / 3;
                switch (n)
                {
                    case 1:
                        return String.Format("{0:0.0} Mhs",data / Math.Pow(1000, 1));
                    case 2:
                        return String.Format("{0:0.0} Ghs", data / Math.Pow(1000, 2));
                    case 3:
                        return String.Format("{0:0.0} Ths", data / Math.Pow(1000, 3));
                    case 4:
                        return String.Format("{0:0.0} Phs", data / Math.Pow(1000, 4));
                    default:
                        return stats.total_khs+" Khs";
                }



               
            }

            static string Get总算力(MachineStats stats)
            {
                string returntext = "";

                long data = 0;
                long.TryParse(stats.total_khs, out data);
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
                            returntext += "|" + String.Format("{0:0.0} Mhs", data2 / Math.Pow(1000, 1));
                            break;
                        case 2:
                            returntext += "|" + String.Format("{0:0.0} Ghs", data2 / Math.Pow(1000, 2)); break;
                        case 3:
                            returntext += "|" + String.Format("{0:0.0} Ths", data2 / Math.Pow(1000, 3)); break;
                        case 4:
                            returntext += "|" + String.Format("{0:0.0} Phs", data2 / Math.Pow(1000, 4)); break;
                        default:
                            returntext += "|" + stats.total_khs + " Khs"; break;
                    }



                }

                return returntext;
            }


        }

        public static Machine_info GetMachine_infoFromhello( MachineHello hello,string rig_name)
        {
            

            var model = new Machine_info();
            model.rig_id = hello.rig_id;
            model.主机名 = rig_name;// showlist.RigName;
            model.状态 = "在线";// showlist.OnOff;
            //model.算力 = Get算力(stats);
            //model.接受率 = Get接受率(stats); ;
            //model.温度 = Get温度(stats);
            //model.挖矿时长 = Get挖矿时长(stats);
            model.显卡 = Get显卡(hello); ;
            //model.模板 = stats.Mining;
            model.IP = hello.ip?.FirstOrDefault();
            //model.备注 = showlist.Other;
            return model;

          
            static string Get显卡(MachineHello hello)
            {
                string card = "";
                Dictionary<string, int> dict = new Dictionary<string, int>();
                var Gpus = JArray.Parse(hello.gpu);


                for (int i = 0; i < Gpus.Count; i++)
                {
                    if (Gpus[i]["busid"] != null)
                    {
                        var str = Gpus[i]["name"].ToString();
                        var type = Gpus[i]["brand"]?.ToString().ToLower();
                        if (type == "cpu")
                        {
                            continue;
                        }
                        if (dict.ContainsKey(str))
                        {
                            dict[str] += 1;
                        }
                        else
                        {
                            dict.Add(str, 1);
                        }
                    }
                }
                #region MyRegion
              
                var stringBuilder = new StringBuilder();
                foreach (KeyValuePair<string, int> item in dict)
                {
                    stringBuilder.Append($"\"{item.Key}\"*{item.Value}   ");
                }
                card = stringBuilder.ToString();

                #endregion
                return card;
            }

            
        }

        private bool _IsSelect;
        [SugarColumn(IsIgnore = true)]
        public bool IsSelect { get=> _IsSelect; set{ _IsSelect = value; PropertyChanged?.Invoke(this, new(nameof(IsSelect)));  } }

    }
}
