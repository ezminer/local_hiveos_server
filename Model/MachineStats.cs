using SqlSugar;
using System;
using System.Collections.Generic;

namespace Model
{

   



    //如果好用，请收藏地址，帮忙分享。
    public class Custom
    {
        /// <summary>
        /// 
        /// </summary>
        public string coin { get; set; }
    }

    public class Meta
    {
        /// <summary>
        /// 
        /// </summary>
        public Custom custom { get; set; }
    }


    public class Miner_stats
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> hs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> mtemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hs_units { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string algo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> bus_numbers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> temp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> fan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int uptime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yanchi { get; set; }




        public List<string> hs2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hs_units2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ar2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string algo2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_khs2 { get; set; }
    }
    

    //如果好用，请收藏地址，帮忙分享。
    [SugarTable("machine_stats")]
    public class MachineStats { 

        /// <summary>
        /// 
        /// </summary>
    public int v { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(ColumnName = "rig_id", IsPrimaryKey = true)]
        public string rig_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string passwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public Meta meta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> temp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> fan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> power { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string df { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> mem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> cputemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<string> cpuavg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string miner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_khs { get; set; }

        public DateTime updatetime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public Miner_stats miner_stats { get; set; }
    }







}
