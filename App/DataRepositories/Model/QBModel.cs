using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DataRepositories.Model;

namespace MyApp.Models
{
    public class QBModel
    {
        [Key]
        public int ID { get; set; }
      
        [StringLength(50)]
        public string 钱包名称 { get; set; }  

        [StringLength(50)]
        public string 币种 { get; set; }
        [StringLength(200)]
        public string 钱包地址 { get; set; }
        public QBModel Copy() => new () { 钱包名称 = 钱包名称, 币种 = 币种, 钱包地址 = 钱包地址};
    
        public List<WKModel> WKList { get; set; }

    }
}
