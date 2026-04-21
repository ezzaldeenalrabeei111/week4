using System;
using DIPNotificationService.Core;

namespace DIPNotificationService.Services
{
    /// <summary>
    /// خدمة إرسال البريد الإلكتروني. تطبق واجهة IMessageService.
    /// تمثل وحدة منخفضة المستوى تعتمد على التجريد (IMessageService).
    /// </summary>
    public class EmailService : IMessageService
    {
        /// <summary>
        /// إرسال رسالة بريد إلكتروني.
        /// </summary>
        /// <param name="recipient">عنوان البريد الإلكتروني للمستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"EmailService: Sending email to {recipient} with message: \"{message}\"");
            // هنا يمكن إضافة منطق إرسال البريد الإلكتروني الفعلي
        }
    }
}
