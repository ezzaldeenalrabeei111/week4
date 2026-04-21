using System;
using System.Collections.Generic;
using DIPNotificationService.Core;
using DIPNotificationService.Managers;
using DIPNotificationService.Services;

namespace DIPNotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- DIP Notification Service Demo ---");

            // 1. إنشاء التنفيذات الملموسة (Low-level modules)
            // هذه هي الخدمات الفعلية التي تقوم بالإرسال والتسجيل.
            IMessageService emailService = new EmailService();
            IMessageService smsService = new SmsService();
            ILogger consoleLogger = new ConsoleLogger();

            // 2. تجميع خدمات الرسائل في قائمة
            // يمكننا إضافة أو إزالة خدمات هنا دون التأثير على NotificationManager.
            List<IMessageService> messageServices = new List<IMessageService>
            {
                emailService,
                smsService
            };

            // 3. حقن التبعيات (Dependency Injection)
            // NotificationManager (High-level module) يعتمد على التجريدات (IMessageService, ILogger)
            // ولا يعرف شيئاً عن التنفيذات الملموسة (EmailService, SmsService, ConsoleLogger).
            NotificationManager notificationManager = new NotificationManager(messageServices, consoleLogger);

            Console.WriteLine("\n----------------------------------------");

            // 4. استخدام NotificationManager لإرسال الإشعارات
            // لاحظ أننا لا نحدد نوع الخدمة هنا، بل NotificationManager هو من يدير ذلك.
            notificationManager.SendNotification("user@example.com", "Hello via DIP! (Email & SMS)");

            Console.WriteLine("\n----------------------------------------");

            notificationManager.SendNotification("+1234567890", "Urgent update! (Email & SMS)");

            Console.WriteLine("\n--- End of DIP Demo ---");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
