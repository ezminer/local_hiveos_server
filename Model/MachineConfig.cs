using SqlSugar;

namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("machine_config")]
    public partial class MachineConfig
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
     
        [SugarColumn(ColumnName = "addtime")]
        public string Addtime { get; set; }
     

        [SugarColumn(ColumnName = "rig_name")]
        public string RigName { get; set; }   
        [SugarColumn(ColumnName = "config")]
        public string Config { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "wallet")]
        public string Wallet { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "autofan")]
        public string Autofan { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "amd_oc")]
        public string AmdOc { get; set; }
        /// <summary>
        ///  
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "nvidia_oc")]
        public string NvidiaOc { get; set; }
    }
}
