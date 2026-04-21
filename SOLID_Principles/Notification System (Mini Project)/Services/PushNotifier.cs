using System;

namespace NotificationSystem.Services
{
    /// <summary>
    /// خدمة إرسال الإشعارات الفورية (Push Notification). تتبع مبدأ الفتح/الغلق (OCP) ومبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class PushNotifier : NotificationSystem.Core.INotificationService
    {
        /// <summary>
        /// إرسال إشعار فوري.
        /// </summary>
        /// <param name="recipient">معرف الجهاز أو المستخدم المستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void Send(string recipient, string message)
        {
            // محاكاة إرسال إشعار فوري
            Console.WriteLine($"[PushNotifier] Sending push notification to {recipient}: {message}");
        }
    }
}
