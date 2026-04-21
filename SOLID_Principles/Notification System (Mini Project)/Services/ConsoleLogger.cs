using System;

namespace NotificationSystem.Services
{
    /// <summary>
    /// خدمة تسجيل الرسائل على الكونسول. تتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class ConsoleLogger : NotificationSystem.Core.ILogger
    {
        /// <summary>
        /// تسجيل رسالة معلوماتية على الكونسول.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }

        /// <summary>
        /// تسجيل رسالة خطأ على الكونسول.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        public void LogError(string message)
        {
            Console.Error.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        }
    }
}
