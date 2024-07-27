using System;

namespace MyApp.Contracts.Services
{
    public interface IApplicationInfoService
    {
        Version GetVersion();
    }
}
