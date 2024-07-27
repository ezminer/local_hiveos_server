using System;
using System.Diagnostics;
using System.Reflection;

using MyApp.Contracts.Services;

namespace MyApp.Services
{
    /// <summary>
    /// 应用程序信息服务
    /// </summary>
    public class ApplicationInfoService : IApplicationInfoService
    {
        public ApplicationInfoService()
        {
        }

        public Version GetVersion()
        {
            // Set the app version in WPFTemple > Properties > Package > PackageVersion
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
            return new Version(version);
        }
    }
}
