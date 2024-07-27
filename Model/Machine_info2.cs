using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [SugarTable("machine_info2")]
    public partial class Machine_info2
    {
        [SugarColumn(ColumnName = "rig_id", IsPrimaryKey = true)]
        public string rig_id { get; set; }
        public string 主机名 { get; set; }
        public string 总算力 { get; set; }
        public string 总功耗 { get; set; }

        [SqlSugar.SugarColumn(IsJson = true)]//必填
        public List<显卡信息> 显卡信息 { get; set; }


        public string 挖矿时长 { get; set; }
        public string 挖矿模板 { get; set; }
        public string 币种 { get; set; }
        public string 算法 { get; set; }
        public string 核心版本 { get; set; }
        public string 有效率 { get; set; }
        public string 有效 { get; set; }
        public string 无效 { get; set; }
        public string 拒绝 { get; set; }


        public string 在线时长 { get; set; }
        public string 内网IP { get; set; }
        public string 外网IP { get; set; }
        public string A卡驱动 { get; set; }

        public string N卡驱动 { get; set; }
        public string 固件版本 { get; set; }
        public string cpu型号 { get; set; }
        public string CPU核心数 { get; set; }
        public string 主板厂家 { get; set; }
        public string 主板型号 { get; set; }
        public string 本地磁盘 { get; set; }
        public string Mac地址 { get; set; }
        public string cpu使用率 { get; set; }
        public string 内存大小 { get; set; }
        public string 可用内存 { get; set; }
        public string 延迟 { get; set; }
        public string 内核版本 { get; set; }

    }
   public class 显卡信息 
    {

        public string 实时功耗 { get; set; }
        public string 算力 { get; set; }
        public string 显卡温度 { get; set; }

        public string 显存温度 { get; set; }
        public string 风扇 { get; set; }
        public string 显卡型号 { get; set; }
        public string 品牌 { get; set; }
        public string 显存大小 { get; set; }
        public string 颗粒 { get; set; }
        public string 最小功耗 { get; set; }
        public string 默认功耗 { get; set; }
        public string 单卡拒绝 { get; set; }

    }
  
   


}
