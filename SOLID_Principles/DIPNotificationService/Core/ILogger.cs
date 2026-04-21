using System;

namespace DIPNotificationService.Core
{
    /// <summary>
    /// واجهة لخدمات التسجيل (مثل التسجيل في الكونسول أو في ملف).
    /// تمثل التجريد الذي يعتمد عليه NotificationManager.
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
