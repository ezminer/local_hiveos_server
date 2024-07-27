using SqlSugar;
using System.Collections.Generic;

namespace Model
{
   

    //如果好用，请收藏地址，帮忙分享。
    public class Net_interfacesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string iface { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mac { get; set; }
    }

    public class Lan_config
    {
        /// <summary>
        /// 
        /// </summary>
        public int dhcp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gateway { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dns { get; set; }
    }

    public class GpuItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string busid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string brand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subvendor { get; set; }
    }

    public class Mb
    {
        /// <summary>
        /// 
        /// </summary>
        public string manufacturer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string system_uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bios { get; set; }
    }

    public class Cpu
    {
        /// <summary>
        /// 
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cores { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cpu_id { get; set; }
    }

    [SugarTable("machine_hello")]
    public class MachineHello
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(ColumnName = "rig_id", IsPrimaryKey = true)]
        public string rig_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string addtime { get; set; }
        public string passwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string server_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ref_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string boot_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string boot_event { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(IsJson = true)]//必填
        public List<string> ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public List<Net_interfacesItem> net_interfaces { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string openvpn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public Lan_config lan_config { get; set; }
        /// <summary>
        /// 
        /// </summary>
        
        public string gpu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gpu_count_amd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gpu_count_nvidia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public Mb mb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [SqlSugar.SugarColumn(ColumnDataType = "varchar(max)", IsJson = true)]//必填
        public Cpu cpu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disk_model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kernel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string amd_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nvidia_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string farm_hash { get; set; }
    }





}
