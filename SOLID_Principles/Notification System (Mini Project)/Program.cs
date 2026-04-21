using System;
using System.Collections.Generic;
using NotificationSystem.Core;
using NotificationSystem.Managers;
using NotificationSystem.Services;

namespace NotificationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. إعداد خدمات التسجيل (Loggers)
            // يتم إنشاء ConsoleLogger و FileLogger. FileLogger يتطلب مسار ملف.
            ILogger consoleLogger = new ConsoleLogger();
            ILogger fileLogger = new FileLogger("notification_log.txt");

            // يمكننا استخدام أي من الـ loggers هنا، أو حتى logger يجمع بينهما.
            // لأغراض العرض، سنستخدم consoleLogger لتبسيط المخرجات على الشاشة.
            ILogger primaryLogger = consoleLogger;

            primaryLogger.LogInfo("Notification System Demo Started.");

            // 2. إعداد خدمات الإشعارات (Notifiers)
            // يتم إنشاء جميع خدمات الإشعارات المتاحة.
            INotificationService emailNotifier = new EmailNotifier();
            INotificationService smsNotifier = new SmsNotifier();
            INotificationService pushNotifier = new PushNotifier();

            // تجميع جميع خدمات الإشعارات في قائمة ليتم حقنها في NotificationManager.
            List<INotificationService> notifiers = new List<INotificationService>
            {
                emailNotifier,
                smsNotifier,
                pushNotifier
            };

            // 3. إنشاء NotificationManager باستخدام حقن التبعية (Dependency Injection)
            // NotificationManager يعتمد على الواجهات (IEnumerable<INotificationService> و ILogger) وليس على التنفيذات الملموسة.
            NotificationManager manager = new NotificationManager(notifiers, primaryLogger);

            Console.WriteLine("\n--- Sending Notifications ---\n");

            // 4. إرسال إشعارات بأولويات مختلفة لاختبار النظام

            // رسالة ذات أولوية منخفضة (Low Priority)
            // لا ينبغي أن يتم إرسالها عبر أي قناة.
            manager.SendNotification("user@example.com", "This is a low priority reminder.", MessagePriority.Low);
            Console.WriteLine("\n----------------------------------\n");

            // رسالة ذات أولوية متوسطة (Medium Priority)
            // يجب أن تذهب إلى البريد الإلكتروني فقط.
            manager.SendNotification("user@example.com", "Your subscription is about to expire.", MessagePriority.Medium);
            Console.WriteLine("\n----------------------------------\n");

            // رسالة ذات أولوية عالية (High Priority)
            // يجب أن تذهب إلى البريد الإلكتروني والرسائل القصيرة.
            manager.SendNotification("user@example.com", "Important security alert for your account.", MessagePriority.High);
            Console.WriteLine("\n----------------------------------\n");

            // رسالة ذات أولوية حرجة (Critical Priority)
            // يجب أن تذهب إلى جميع القنوات المتاحة (Email, SMS, Push).
            manager.SendNotification("user@example.com", "System outage detected! Immediate action required.", MessagePriority.Critical);
            Console.WriteLine("\n----------------------------------\n");

            primaryLogger.LogInfo("Notification System Demo Finished.");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
