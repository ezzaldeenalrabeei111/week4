using System;
using System.Collections.Generic;
using System.Linq;
using NotificationSystem.Core;

namespace NotificationSystem.Managers
{
    /// <summary>
    /// يدير إرسال الإشعارات بناءً على الأولويات وخدمات الإشعارات المتاحة.
    /// يتبع مبدأ عكس التبعية (DIP) ومبدأ الفتح/الغلق (OCP).
    /// </summary>
    public class NotificationManager
    {
        private readonly IEnumerable<INotificationService> _notificationServices;
        private readonly ILogger _logger;

        /// <summary>
        /// منشئ الكلاس NotificationManager.
        /// يعتمد على مجموعة من خدمات الإشعارات وخدمة تسجيل (Logger) عبر حقن التبعية.
        /// </summary>
        /// <param name="notificationServices">مجموعة من خدمات الإشعارات المتاحة.</param>
        /// <param name="logger">خدمة التسجيل.</param>
        public NotificationManager(IEnumerable<INotificationService> notificationServices, ILogger logger)
        {
            // التحقق من أن الخدمات ليست فارغة لتجنب الأخطاء.
            if (notificationServices == null || !notificationServices.Any())
            {
                throw new ArgumentNullException("notificationServices", "Notification services cannot be null or empty.");
            }
            if (logger == null)
            {
                throw new ArgumentNullException("logger", "Logger cannot be null.");
            }

            _notificationServices = notificationServices;
            _logger = logger;
            _logger.LogInfo("NotificationManager initialized with available services.");
        }

        /// <summary>
        /// إرسال إشعار إلى مستلم معين برسالة محددة وأولوية معينة.
        /// </summary>
        /// <param name="recipient">المستلم (مثال: عنوان البريد الإلكتروني، رقم الهاتف).</param>
        /// <param name="message">نص الرسالة المراد إرسالها.</param>
        /// <param name="priority">أولوية الرسالة.</param>
        public void SendNotification(string recipient, string message, MessagePriority priority)
        {
            _logger.LogInfo(string.Format("Attempting to send notification to {0} with priority {1}: {2}", recipient, priority, message));

            switch (priority)
            {
                case MessagePriority.Low:
                    // الرسائل ذات الأولوية المنخفضة لا يتم إرسالها عبر أي قناة في هذا السيناريو.
                    _logger.LogInfo("Low priority message. No notification sent.");
                    break;

                case MessagePriority.Medium:
                    // الرسائل ذات الأولوية المتوسطة تذهب إلى البريد الإلكتروني فقط.
                    var emailNotifier = _notificationServices.OfType<NotificationSystem.Services.EmailNotifier>().FirstOrDefault();
                    if (emailNotifier != null)
                    {
                        emailNotifier.Send(recipient, message);
                        _logger.LogInfo("Medium priority message sent via Email.");
                    }
                    else
                    {
                        _logger.LogError("EmailNotifier not found for medium priority message.");
                    }
                    break;

                case MessagePriority.High:
                    // الرسائل ذات الأولوية العالية تذهب إلى البريد الإلكتروني والرسائل القصيرة.
                    foreach (var service in _notificationServices)
                    {
                        if (service is NotificationSystem.Services.EmailNotifier || service is NotificationSystem.Services.SmsNotifier)
                        {
                            service.Send(recipient, message);
                            _logger.LogInfo(string.Format("High priority message sent via {0}.", service.GetType().Name));
                        }
                    }
                    break;

                case MessagePriority.Critical:
                    // الرسائل ذات الأولوية الحرجة تذهب إلى جميع القنوات المتاحة.
                    foreach (var service in _notificationServices)
                    {
                        service.Send(recipient, message);
                        _logger.LogInfo(string.Format("Critical priority message sent via {0}.", service.GetType().Name));
                    }
                    break;

                default:
                    _logger.LogError(string.Format("Unknown message priority: {0}. No notification sent.", priority));
                    break;
            }
        }
    }
}
