using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("task_done")]
    public class TaskDone
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public long Id { get; set; }
        /// <summary>
        ///  
        /// 默认值: (N'')
        ///</summary>
         [SugarColumn(ColumnName="passwd"    )]
         public string Passwd { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="addtime"    )]
         public string Addtime { get; set; }
        /// <summary>
        ///  
        /// 默认值: (N'')
        ///</summary>
         [SugarColumn(ColumnName="rig_id"    )]
         public string RigId { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="payload"    )]
         public string Payload { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="data"    )]
         public string Data { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="list_id"    )]
         public long? ListId { get; set; }
    }
}
