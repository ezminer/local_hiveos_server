using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
   
    //如果好用，请收藏地址，帮忙分享。
    public class 核心下载地址Item
    {
        /// <summary>
        /// 
        /// </summary>
        public string 核心名字 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 下载地址 { get; set; }
    }

    public class 矿池Item
    {
        /// <summary>
        /// 
        /// </summary>
        public string 名字 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 代理 { get; set; }
    }

    public class 币种Item
    {
        /// <summary>
        /// 
        /// </summary>
        public string 币种 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<核心下载地址Item> 核心下载地址 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<矿池Item> 矿池 { get; set; }
    }

    public class 挖矿模板Json
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        public List<币种Item> data { get; set; }
    }

}
