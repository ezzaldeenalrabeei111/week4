using System;
using DIPNotificationService.Core;

namespace DIPNotificationService.Services
{
    /// <summary>
    /// خدمة التسجيل على الكونسول. تطبق واجهة ILogger.
    /// تمثل وحدة منخفضة المستوى تعتمد على التجريد (ILogger).
    /// </summary>
    public class ConsoleLogger : ILogger
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
