using System;

namespace NotificationSystem.Services
{
    /// <summary>
    /// خدمة إرسال الإشعارات عبر البريد الإلكتروني. تتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class EmailNotifier : NotificationSystem.Core.INotificationService
    {
        /// <summary>
        /// إرسال إشعار عبر البريد الإلكتروني.
        /// </summary>
        /// <param name="recipient">عنوان البريد الإلكتروني للمستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void Send(string recipient, string message)
        {
            // محاكاة إرسال بريد إلكتروني
            Console.WriteLine($"[EmailNotifier] Sending email to {recipient}: {message}");
        }
    }
}
