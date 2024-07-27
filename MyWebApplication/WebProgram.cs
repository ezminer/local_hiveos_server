using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyWebApplication.IService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseWindowsService()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                //   webBuilder.UseUrls(Model.Config.Default.SERVERIP);
                });
    }
    public class WebProgram
    {
        static private IHost host;
        static private  ISQLQueueService SQLQueue;
        public static void Run()
        {

            try
            {
                //Trace.Listeners.Add(new TextWriterTraceListener(File.OpenWrite("Log.txt")));
                //Trace.AutoFlush = true;

                Thread.CurrentThread.Name = "web线程";
                host = CreateHostBuilder(null).Build();
                //sql队列服务
                SQLQueue = (host.Services.GetService(typeof(ISQLQueueService)) as ISQLQueueService);
                SQLQueue.RunSQLQueueService();
                host.Run();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }
        }


       


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseWindowsService()
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.UseUrls(Model.Config.Default.SERVERIP);
                   // webBuilder.UseUrls(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "服务器地址.txt"));
                });
    }
}
