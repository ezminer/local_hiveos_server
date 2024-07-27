using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace Model
{
    /// <summary>
    /// 
    ///</summary>
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("mining")]
    public class Mining
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 矿池名称 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "pool_name")]
        public string PoolName { get; set; }

        /// <summary>
        /// 默认模板 0 自定义模板1 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "默认模板")]
        public int 默认模板 { get; set; }
        /// <summary>
        /// 矿池地址 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "pool_addr")]
        public string PoolAddr { get; set; }
     
        /// <summary>
        /// 模板名称 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "mining_name")]
        public string MiningName { get; set; }
        /// <summary>
        /// 币种名称 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "coin_name")]
        public string CoinName { get; set; }
       
        /// <summary>
        /// 钱包地址 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "wallet_addr")]
        public string WalletAddr { get; set; }
        /// <summary>
        /// 核心下载地址 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "minerver_addr")]
        public string MinerverAddr { get; set; }
        /// <summary>
        /// 核心名称 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "minerver_name")]
        public string MinerverName { get; set; }
        /// <summary>
        /// 自定义参数 
        /// 默认值: (NULL)
        ///</summary>
        [SugarColumn(ColumnName = "user_config")]
        public string UserConfig { get; set; }

        [SugarColumn(ColumnName = "password")]
        public string password { get; set; }


        [SugarColumn(ColumnName = "挖矿软件名称")]
        public string 挖矿软件名称 { get; set; }

        [SugarColumn(ColumnName = "加密算法")]
        public string 加密算法 { get; set; }
    }
}
