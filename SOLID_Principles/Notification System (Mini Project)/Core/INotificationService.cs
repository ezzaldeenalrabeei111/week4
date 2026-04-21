using System;

namespace NotificationSystem.Core
{
    /// <summary>
    /// واجهة لخدمات الإشعارات. تتبع مبدأ فصل الواجهات (ISP) ومبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// إرسال إشعار إلى مستلم محدد برسالة معينة.
        /// </summary>
        /// <param name="recipient">المستلم (مثال: عنوان البريد الإلكتروني، رقم الهاتف).</param>
        /// <param name="message">نص الرسالة المراد إرسالها.</param>
        void Send(string recipient, string message);
    }
}
