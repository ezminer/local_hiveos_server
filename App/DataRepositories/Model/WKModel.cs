namespace MyApp.DataRepositories.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MyApp.Models;

    public partial class WKModel
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(200)]
        public string 模板名称 { get; set; }

        [StringLength(200)]
        public string 币种 { get; set; }

        [StringLength(200)]
        public string 矿池 { get; set; }
        [Required]
        public int 钱包ID { get; set; }
        [ForeignKey("钱包ID")]
        public virtual QBModel QBModel { get; set; }

        [StringLength(200)]
        public string 核心 { get; set; }

        [StringLength(200)]
        public string 核心版本 { get; set; }

        [StringLength(200)]
        public string 自定义参数 { get; set; }
    }
}
