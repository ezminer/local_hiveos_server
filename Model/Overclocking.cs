using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("overclocking")]
    public class Overclocking
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int Id { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="oc_name"    )]
         public string OcName { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="core_clock"    )]
         public string CoreClock { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="core_state"    )]
         public string CoreState { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="core_vddc"    )]
         public string CoreVddc { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="mem_clock"    )]
         public string MemClock { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="mem_state"    )]
         public string MemState { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="afan"    )]
         public string Afan { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="aggressive"    )]
         public int? Aggressive { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="clock"    )]
         public string Clock { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="mem"    )]
         public string Mem { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="nfan"    )]
         public string Nfan { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="plimit"    )]
         public string Plimit { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="logo_brightness"    )]
         public int? LogoBrightness { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="ohgodapill_enabled"    )]
         public int? OhgodapillEnabled { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="ohgodapill_start_timeout"    )]
         public int? OhgodapillStartTimeout { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="ohgodapill_args"    )]
         public int? OhgodapillArgs { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="running_delay"    )]
         public int? RunningDelay { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="user_name"    )]
         public string UserName { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="autofan"    )]
         public string Autofan { get; set; }
    }
}
