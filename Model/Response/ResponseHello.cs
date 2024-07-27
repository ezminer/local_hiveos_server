namespace Model.Response
{
   
    //如果好用，请收藏地址，帮忙分享。
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public string rig_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string config { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wallet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string autofan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string amd_oc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nvidia_oc { get; set; }
    }

     public class ResponseHello
    {
        /// <summary>
        /// 
        /// </summary>
        public string jsonrpc { get; set; } = "2.0";
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
    }

}
