using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using System;
    using System.IO;

    public class Example
    {
        public static string Config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/rig.conf.txt");
        public static string Amd = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/amd-oc.conf.txt");
        public static string Nvidia = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/nvidia-oc.conf.txt");
        public static string Wallet = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/wallet.conf.txt");
        public static string Autofan = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Configtemplate/autofan.conf.txt");
        public static void Main()
        {
            var xx = Wallet;


        }

        
    }
}
