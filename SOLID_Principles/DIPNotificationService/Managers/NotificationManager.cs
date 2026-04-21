using System;
using System.Collections.Generic;
using DIPNotificationService.Core;

namespace DIPNotificationService.Managers
{
    /// <summary>
    /// كلاس NotificationManager مسؤول عن إرسال الإشعارات.
    /// يعتمد على التجريدات (IMessageService و ILogger) بدلاً من التنفيذات الملموسة (تطبيق DIP).
    /// </summary>
    public class NotificationManager
    {
        private readonly IEnumerable<IMessageService> _messageServices;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor يقوم بحقن التبعيات (IMessageService و ILogger).
        /// </summary>
        /// <param name="messageServices">قائمة بخدمات الرسائل المتاحة.</param>
        /// <param name="logger">خدمة التسجيل.</param>
        public NotificationManager(IEnumerable<IMessageService> messageServices, ILogger logger)
        {
            _messageServices = messageServices ?? throw new ArgumentNullException(nameof(messageServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogInfo("NotificationManager initialized.");
        }

        /// <summary>
        /// إرسال إشعار إلى مستلم محدد.
        /// </summary>
        /// <param name="recipient">المستلم.</param>
        /// <param name="message">نص الرسالة.</param>
        public void SendNotification(string recipient, string message)
        {
            _logger.LogInfo($"Attempting to send notification to {recipient}: \"{message}\"");
            foreach (var service in _messageServices)
            {
                try
                {
                    service.Send(recipient, message);
                    _logger.LogInfo($"Notification sent successfully via {service.GetType().Name} to {recipient}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to send notification via {service.GetType().Name} to {recipient}. Error: {ex.Message}");
                }
            }
            _logger.LogInfo($"Finished processing notification for {recipient}.");
        }
    }
}
