using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Contracts.Services
{
    internal interface ITimerTaskService
    {
        void Run();
        void Stop();
    }
}
