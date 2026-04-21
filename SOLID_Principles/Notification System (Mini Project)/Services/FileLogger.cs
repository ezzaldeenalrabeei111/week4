using System;
using System.IO;

namespace NotificationSystem.Services
{
    /// <summary>
    /// خدمة تسجيل الرسائل في ملف. تتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class FileLogger : NotificationSystem.Core.ILogger
    {
        private readonly string _logFilePath;

        /// <summary>
        /// منشئ الكلاس FileLogger.
        /// </summary>
        /// <param name="logFilePath">المسار الكامل لملف السجل.</param>
        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        /// <summary>
        /// تسجيل رسالة معلوماتية في الملف.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        public void LogInfo(string message)
        {
            try
            {
                File.AppendAllText(_logFilePath, string.Format("[INFO] {0}: {1}{2}", DateTime.Now, message, Environment.NewLine));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[FileLogger Error] Could not write info to log file: {ex.Message}");
            }
        }

        /// <summary>
        /// تسجيل رسالة خطأ في الملف.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        public void LogError(string message)
        {
            try
            {
                File.AppendAllText(_logFilePath, string.Format("[ERROR] {0}: {1}{2}", DateTime.Now, message, Environment.NewLine));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[FileLogger Error] Could not write error to log file: {ex.Message}");
            }
        }
    }
}
