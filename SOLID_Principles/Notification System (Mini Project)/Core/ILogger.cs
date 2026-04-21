using System;

namespace NotificationSystem.Core
{
    /// <summary>
    /// واجهة لخدمات التسجيل (Logging). تتبع مبدأ فصل الواجهات (ISP) ومبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// تسجيل رسالة معلوماتية.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        void LogInfo(string message);

        /// <summary>
        /// تسجيل رسالة خطأ.
        /// </summary>
        /// <param name="message">الرسالة المراد تسجيلها.</param>
        void LogError(string message);
    }
}
