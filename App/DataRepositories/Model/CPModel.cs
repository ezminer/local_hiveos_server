namespace MyApp.DataRepositories.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class CPModel
    {   [Key]
        public int ID { get; set; }
    
        [StringLength(50)]
        public string 模板名称 { get; set; }
       
        [StringLength(50)]
        public string N核心频率 { get; set; }
     
        [StringLength(50)]
        public string N显存频率 { get; set; }
     
        [StringLength(50)]
        public string N功耗限制 { get; set; }
      
        [StringLength(50)]
        public string N风扇转速 { get; set; }

        [StringLength(50)]
        public string A核心频率 { get; set; }

        [StringLength(50)]
        public string A核心状态 { get; set; }

        [StringLength(50)]
        public string A核心电压 { get; set; }

        [StringLength(50)]
        public string A显存频率 { get; set; }

        [StringLength(50)]
        public string A风扇转速 { get; set; }
    }
}
