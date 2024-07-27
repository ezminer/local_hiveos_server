using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [SugarTable("Machine_info")]
    public partial class Machine_info
    {

       
        public string 状态 { get; set; }
        public string 主机名 { get; set; }
        public string 算力 { get; set; }
        public string 接受率 { get; set; }
        public string 温度 { get; set; }
        public string 挖矿时长 { get; set; }
        public string 显卡 { get; set; }
        public string 模板 { get; set; }
        public string IP { get; set; }
        public string 备注 { get; set; }
        [SugarColumn(ColumnName = "rig_id", IsPrimaryKey = true)]
        public string rig_id { get; set; }
    }
}
