using Microsoft.AspNetCore.Mvc;
using Model;
using MyWebApplication.IService;

using MyWebApplication.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;
///tcp://b77814903.6655.la:55368
//tcp://b77814903.6655.la:16087
namespace MyWebApplication.Controllers
{
    [ApiController]
   
    [Route("{controller}/{action}/{id?}")]
    public class WorkerController : ControllerBase
    {
       
       
        private  static string url = Model.Config.Default.SERVERIP;
        private  static HelloService helloService;
        private  static StatsService statsService;
        private static SqlSugarScope db;

        public WorkerController(SqlSugarScope _db   )
        {

            if (db == null)
            {
                db = _db;
                
                helloService = new HelloService(url, db );
                statsService = new StatsService(url, db );
            }
           

        }


        [HttpPost]
        public  async Task<string> api()
        {
            try
            {
                var sr = new StreamReader(Request.Body, System.Text.Encoding.UTF8);
                string jsondata = sr.ReadToEndAsync().Result;
                JObject respJobject = JObject.Parse(jsondata);

                var method = respJobject["method"]?.ToString() ?? "";
                JToken @params = respJobject["params"];

                if (method == "hello")
                {
                   string d =await helloService.hello(@params.ToString());

                    Console.WriteLine("****************************************************");
                    Console.WriteLine();
                    Console.WriteLine(d);
                    Console.WriteLine();
                    Console.WriteLine("****************************************************");

                    return await Task.FromResult(d);

                }


                if (method == "stats")
                {

                    string d = await statsService.stats(@params.ToString());
                    Console.WriteLine("****************************************************");
                    Console.WriteLine();
                    Console.WriteLine(d);
                    Console.WriteLine();
                    Console.WriteLine("****************************************************");
                    return d;

                }
                if (method == "message")
                {

                   
                    string d = await message(@params.ToString());
                    Console.WriteLine("****************************************************");
                    Console.WriteLine();
                    Console.WriteLine(d);
                    Console.WriteLine();
                    Console.WriteLine("****************************************************");
                    return d;


                }


            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            return "";
        }



        [HttpGet]
        [Route("")]
        public string index() {
            return "ok"; }
     

        private async Task<string> message(string Content)
        {
            string DataResult = "";
            try
            {
                JObject Json= JObject.Parse(Content);

           var Insert_TaskDone=     new TaskDone()
                {
                    Addtime = DateTime.Now.ToString("G"),
                    Data = Json["data"]?.ToString(),
                    ListId = ((long)Json["id"]),
                    Passwd = Json["passwd"]?.ToString(),
                    Payload = Json["payload"]?.ToString(),
                    RigId = Json["rig_id"]?.ToString(),
                };

                //if (Db.Queryable<TaskDone>().First(s=>s.ListId== Insert_TaskDone.ListId)==null)
                //{
                  
                //}
                db.Insertable(Insert_TaskDone).ExecuteCommand();
                DataResult = "{\"jsonrpc\":\"2.0\",\"result\":null,\"id\":null }";
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }


            return await Task.FromResult(DataResult);

        }
    

    }
}
