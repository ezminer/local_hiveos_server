using MyApp.Core.Contracts.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace MyApp.Core.Services
{
   

    public enum Level
    {/// <summary>
     /// ALL Level是最低等级的，用于打开所有日志记录。
     /// </summary>
        All,
        /// <summary>
        /// DEBUG Level指出细粒度信息事件对调试应用程序是非常有帮助的。记录系统用于调试的一切信息，内容或者是一些关键数据内容的输出。
        /// </summary>
        DEBUG,
        /// <summary>
        /// INFO level表明 消息在粗粒度级别上突出强调应用程序的运行过程。
        /// </summary>
        INFO,
        /// <summary>
        /// WARN level表明会出现潜在错误的情形。 记录系统中不影响系统继续运行，但不符合系统运行正常条件，有可能引起系统错误的信息。例如，记录内容为空，数据内容不正确等。
        /// </summary>
        WARN,
        /// <summary>
        /// ERROR level指出虽然发生错误事件，但仍然不影响系统的继续运行。记录系统中出现的导致系统不稳定，部分功能出现混乱或部分功能失效一类的错误。例如，数据字段为空，数据操作不可完成，操作出现异常等。
        /// </summary>
        ERROR,
        /// <summary>
        /// FATAL level指出每个严重的错误事件将会导致应用程序的退出，记录系统中出现的能使用系统完全失去功能，服务停止，系统崩溃等使系统无法继续运行下去的错误。例如，数据库无法连接，系统出现死循环。
        /// </summary>
        FATAL,
        /// <summary>
        /// 	OFF Level是最高等级的，用于关闭所有日志记录
        /// </summary>
        OFF,

    }

    public class MyLog : IMyLog
    {

        private readonly Thread _Thread;
        private readonly ConcurrentQueue<string> 消息队列;
        public string Path { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "Log\\";


        public MyLog()
        {
            消息队列 = new ConcurrentQueue<string>();
            _Thread = new Thread(Loop);
            _Thread.IsBackground = true;
            _Thread.Name = "日志线程";
            _Thread.Start();
        }

        public Level Level { get; set; }
        private void Loop()
        {
            while (true)
            {
                if (消息队列.IsEmpty)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    try
                    {
                        string data;
                        消息队列.TryDequeue(out data);

                        Console.WriteLine(data);

                        File.AppendAllText(GetFileName(), data);

                    }
                    catch (Exception)
                    {


                    }
                }

            }

        }

        private string GetFileName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Path);
            

            if (!Directory.Exists(stringBuilder.ToString()))
            {
                Directory.CreateDirectory(stringBuilder.ToString());
            }

            stringBuilder.Append(DateTime.Now.ToString("M"));
            //stringBuilder.Append("\\");
            //stringBuilder.Append(DateTime.Now.ToString("HH"));
            stringBuilder.Append(".txt");
            string FileName = stringBuilder.ToString();


            return FileName;



        }



        public void WriteException(string msg, Exception exception)
        {
            if (Level > Level.FATAL) return;

            StackTrace st = new StackTrace(1, true);

            //CallerFilePathAttribute
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[致命] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            stringBuilder.Append("  文件:");
            stringBuilder.AppendLine(st.GetFrame(0).GetFileName());
            stringBuilder.Append("  方法:");
            stringBuilder.AppendLine(st.GetFrame(0).GetMethod().Name);
            stringBuilder.Append("  行号:");
            stringBuilder.AppendLine(st.GetFrame(0).GetFileLineNumber().ToString());
            stringBuilder.Append("  描述:");
            stringBuilder.AppendLine(exception?.Message ?? "");
            stringBuilder.Append("  堆栈消息:\n");

            for (int i = st.FrameCount - 1; i >= 0; i--)
            {
                var frame = st.GetFrame(i);
                var method = frame.GetMethod();
                stringBuilder.Append("  ");
                for (int ii = 0; ii < st.FrameCount - i; ii++)
                {
                    stringBuilder.Append("  ");
                }

                stringBuilder.Append(method?.DeclaringType?.FullName);
                stringBuilder.Append(".");
                stringBuilder.Append(method.Name);
                stringBuilder.Append("  行号:");
                stringBuilder.AppendLine(frame.GetFileLineNumber().ToString());
                stringBuilder.AppendLine();


            }
            stringBuilder.AppendLine();
            消息队列.Enqueue(stringBuilder.ToString());


        }

        public void WriteDebug(string msg)
        {
            if (Level > Level.DEBUG) return;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[调试] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            消息队列.Enqueue(stringBuilder.ToString());
        }

        public void WriteINFO(string msg)
        {
            if (Level > Level.INFO) return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[信息] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            消息队列.Enqueue(stringBuilder.ToString());

        }

        public void WriteWRAN(string msg)
        {
            if (Level > Level.WARN) return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[警告] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            消息队列.Enqueue(stringBuilder.ToString());
        }

        public void WriteERROR(string msg)
        {
            if (Level > Level.ERROR) return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[错误] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            消息队列.Enqueue(stringBuilder.ToString());
        }

        public void WriteFATAL(string msg)
        {
            if (Level > Level.FATAL) return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("[致命] ");
            stringBuilder.Append(DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss:FFF"));
            stringBuilder.Append("  -->:");
            stringBuilder.AppendLine(msg ?? "");
            消息队列.Enqueue(stringBuilder.ToString());
        }
    }


}
