using System;
using System.IO;

namespace Store.Repository.Logging
{
    public static class Logger
    {
        private static string GetLogFilePath()
        {
            string logDirectory = "Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFileName = $"{DateTime.Now:yyyy-MM-dd}.log";
            return Path.Combine(logDirectory, logFileName);
        }

        public static void LogError(Exception ex)
        {
            string logFilePath = GetLogFilePath();
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {ex.Message}");
                writer.WriteLine(ex.StackTrace);
            }
        }

        public static void LogInfo(string message)
        {
            string logFilePath = GetLogFilePath();
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}");
            }
        }

        public static void LogWarning(string message)
        {
            string logFilePath = GetLogFilePath();
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [WARNING] {message}");
            }
        }
    }
}
