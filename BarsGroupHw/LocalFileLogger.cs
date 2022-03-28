using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHw
{
    public class LocalFileLogger<T> : ILogger
    {
        private string _filename;

        public LocalFileLogger(string filename)
            => _filename = filename;

        public void LogInfo(string message)
        {
            using (var fstream = new StreamWriter(_filename, true))
            {
                fstream.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
            }
        }

        public void LogWarning(string message)
        {
            using (var fstream = new StreamWriter(_filename, true))
            {
                fstream.WriteLine($"[Warning]: [{typeof(T).Name}] : {message}");
            }
        }

        public void LogError(string message, Exception ex)
        {
            using (var fstream = new StreamWriter(_filename, true))
            {
                fstream.WriteLine($"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
            }
            
        }

        public static void LocalFileLoggerTest<test>()
        {
            var testLog = new LocalFileLogger<test>("testLog.txt");
            testLog.LogInfo("Test logging info");
            testLog.LogWarning("Test logging warning");
            testLog.LogError("Test logging error", new Exception("Test error"));

            var intLog = new LocalFileLogger<int>("testIntLog.txt");
            intLog.LogInfo("Test int logging info");
            intLog.LogWarning("Test int logging warning");
            intLog.LogError("Test int logging error", new Exception("Test int error"));
            Console.WriteLine("Запись завершена");
        }
    }
}
