using System;
using DIPNotificationService.Core;

namespace DIPNotificationService.Services
{
    /// <summary>
    /// خدمة إرسال الرسائل القصيرة (SMS). تطبق واجهة IMessageService.
    /// تمثل وحدة منخفضة المستوى تعتمد على التجريد (IMessageService).
    /// </summary>
    public class SmsService : IMessageService
    {
        /// <summary>
        /// إرسال رسالة قصيرة.
        /// </summary>
        /// <param name="recipient">رقم الهاتف للمستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"SmsService: Sending SMS to {recipient} with message: \"{message}\"");
            // هنا يمكن إضافة منطق إرسال الرسائل القصيرة الفعلي
        }
    }
}
