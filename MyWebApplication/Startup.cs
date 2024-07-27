using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyWebApplication.IService;
using MyWebApplication.Service;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSqlsugarSetup(Configuration);
            services.AddSqlQueueSetup(Configuration);

            //services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApplication", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApplication v1"));
           }

            app.UseStaticFiles(new StaticFileOptions()
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/x-msdownload",
                
                
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllers();
                
              
               
               
            });
        }
    }


    //建一个扩展类
    public static class Serverextension
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration,
        string dbName = "MyDB.db")
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Sqlite,
                ConnectionString = @"data source = " + AppDomain.CurrentDomain.BaseDirectory + dbName,
                IsAutoCloseConnection = true
            },
                db =>
                {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                       Console.WriteLine(sql);//输出sql
                       // Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
                    };
                });
            services.AddSingleton<SqlSugarScope>(sqlSugar);//这边是SqlSugarScope用AddSingleton
        }

        public static void AddSqlQueueSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<ISQLQueueService, SQLQueueService>();
            
        }

    }

}
