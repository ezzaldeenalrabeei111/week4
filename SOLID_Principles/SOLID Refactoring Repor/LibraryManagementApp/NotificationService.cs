using System;

namespace LibraryManagementApp.Services
{
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    public class EmailNotifier : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine("Email Notification to {0}: {1}", recipient, message);
        }
    }

    public class SmsNotifier : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine("SMS Notification to {0}: {1}", recipient, message);
        }
    }

    public class PushNotifier : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine("Push Notification to {0}: {1}", recipient, message);
        }
    }
}
