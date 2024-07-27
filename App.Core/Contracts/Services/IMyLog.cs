using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace MyApp.Core.Contracts.Services
{


    

    public interface IMyLog
    {


        void WriteDebug(string msg);
        void WriteINFO(string msg);
        void WriteWRAN(string msg);
        void WriteERROR(string msg);
        void WriteFATAL(string msg);
        void WriteException(string msg, Exception exception);
    }
   

}
