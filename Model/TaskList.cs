using System;
using SqlSugar;
namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("task_list")]
    public class TaskList
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="id" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public long Id { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="passwd"    )]
         public string Passwd { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="addtime"    )]
         public DateTime? Addtime { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="rig_id"    )]
         public string RigId { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="shell"    )]
         public string Shell { get; set; }
    }
}
