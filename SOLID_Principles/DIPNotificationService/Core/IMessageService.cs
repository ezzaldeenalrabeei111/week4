using System;

namespace DIPNotificationService.Core
{
    /// <summary>
    /// واجهة لخدمات إرسال الرسائل (مثل البريد الإلكتروني، الرسائل القصيرة).
    /// تمثل التجريد الذي يعتمد عليه NotificationManager.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// إرسال رسالة إلى مستلم محدد.
        /// </summary>
        /// <param name="recipient">المستلم (مثل عنوان البريد الإلكتروني أو رقم الهاتف).</param>
        /// <param name="message">نص الرسالة.</param>
        void Send(string recipient, string message);
    }
}
