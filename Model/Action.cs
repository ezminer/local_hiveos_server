using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("action")]
    public class Action
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
         [SugarColumn(ColumnName="action_name"    )]
         public string ActionName { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="shell"    )]
         public string Shell { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
         [SugarColumn(ColumnName="list"    )]
         public int? List { get; set; }
    }
}
