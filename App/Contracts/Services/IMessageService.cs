using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyApp.Contracts.Services
{
    public delegate void ReceiveMessage(object message);

    public static class 消息管理器
    {
        private static Dictionary<string, 消息圈> 消息列表=new Dictionary<string, 消息圈>();

      

     

        public static 消息圈 Get消息圈(string messageTitle)
        {
            if (消息列表.ContainsKey(messageTitle))
            {
                return 消息列表[messageTitle];
            }
            else
            {
                var 消息 = new 消息圈();
                消息列表.Add(messageTitle, 消息);
                return 消息;
            }
           
        }
       
        
        public static void 发布消息(string messageTitle, object message=null)
        {
            if (消息列表.ContainsKey(messageTitle))
            {
                消息列表[messageTitle].发布消息(message);
            }
            else
            {
            }
        }

    }

    public partial class 消息圈 
    {
    
        public event ReceiveMessage 消息提醒;
        public void 发布消息(object message=null)
        {
            消息提醒?.Invoke(message);

        }
       

    }


    public partial  class 消息圈
    {

        public  const string 导航到设备详细页 = "444FC87E-C2D8-4FF0-9231-AF99D6791C2A";




    }

}
