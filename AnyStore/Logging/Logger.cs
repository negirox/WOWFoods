using System;
using System.IO;

namespace AnyStore.DAL
{
    public static class Logger
    {
        private static readonly string logFilePath = $"error_log{DateTime.Now.ToShortDateString()}.txt";

        public static void LogError(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {ex.Message}");
                writer.WriteLine(ex.StackTrace);
            }
        }
    }
}
