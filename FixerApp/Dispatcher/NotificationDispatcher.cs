using FixerApp.Models.DTOs;
using FixerApp.Models.Entities.Enums;
using FixerApp.Services.Interfaces;

namespace FixerApp.Dispatcher
{
    public class NotificationDispatcher
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationDispatcher> _logger;

        public NotificationDispatcher(
            INotificationService notificationService,
            ILogger<NotificationDispatcher> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public void Dispatch(NotificationRequestDto dto)
        {
            try
            {
                switch (dto.Type)
                {
                    case NotificationType.IN_APP:
                        _notificationService.SendNotification(dto);
                        break;

                    case NotificationType.EMAIL:
                        if (!string.IsNullOrWhiteSpace(dto.Email))
                            _notificationService.SendNotificationEmail(dto);
                        break;

                    case NotificationType.SMS:
                        if (!string.IsNullOrWhiteSpace(dto.Phone))
                            _notificationService.SendNotificationSms(dto);
                        break;

                    case NotificationType.PUSH:
                        if (!string.IsNullOrWhiteSpace(dto.FcmToken))
                            _notificationService.SendNotificationFcm(dto);
                        break;

                    default:
                        _logger.LogWarning("Unknown notification type: {Type}", dto.Type);
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to dispatch notification: {Message}", dto.Message);
            }
        }
    }
}
