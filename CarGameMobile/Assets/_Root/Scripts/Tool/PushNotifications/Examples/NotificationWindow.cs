using UnityEngine;
using Tool.PushNotifications.Settings;

namespace Tool.PushNotifications.Examples
{
    internal class NotificationWindow : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private NotificationSettings _settings;
        
        private NotificationSchedulerFactory _factory;
        private INotificationScheduler _scheduler;


        private void Awake()
        {
            _factory = new NotificationSchedulerFactory(_settings);
            _scheduler = _factory.CreateScheduler();
        }

        private void CreateNotification()
        {
            foreach (NotificationData notificationData in _settings.Notifications)
                _scheduler.ScheduleNotification(notificationData);
        }
    }
}
