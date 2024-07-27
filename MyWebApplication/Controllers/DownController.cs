using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    [Route("Down")]
    [Route("{controller}/{action}/{id?}")]
    public class DownController : Controller
    {
        
        [HttpGet]     
        public FileResult Index()
        {
            var fileStream= System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "json.json");


            Task.Delay(1000).Wait();
            var Result = File(fileStream, "application/x-msdownload");
            Result.FileDownloadName = "json.json";

            return Result; 
        }

        [HttpGet]
       
        [Route("/miners/{FileName?}")]     
        public FileResult data()
        {
            var fileStream = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "json.json");
           var d= this.Request;

            var arr = Request.Path.ToString().Split("/");        
            string FileName= arr[arr.Length-1];

            var Result = PhysicalFile(AppDomain.CurrentDomain.BaseDirectory+ Request.Path, "application/x-msdownload");
            Result.FileDownloadName = FileName;

            return Result;
        }

     

    }
}
