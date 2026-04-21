using System;

namespace NotificationSystem.Services
{
    /// <summary>
    /// خدمة إرسال الإشعارات عبر الرسائل القصيرة (SMS). تتبع مبدأ الفتح/الغلق (OCP) ومبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class SmsNotifier : NotificationSystem.Core.INotificationService
    {
        /// <summary>
        /// إرسال إشعار عبر الرسائل القصيرة.
        /// </summary>
        /// <param name="recipient">رقم هاتف المستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void Send(string recipient, string message)
        {
            // محاكاة إرسال رسالة قصيرة
            Console.WriteLine($"[SmsNotifier] Sending SMS to {recipient}: {message}");
        }
    }
}
