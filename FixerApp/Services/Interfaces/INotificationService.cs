using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;

namespace FixerApp.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotification(User user, string message);
        void SendNotification(NotificationRequestDto dto);
        void SendNotificationEmail(NotificationRequestDto dto);
        void SendNotificationSms(NotificationRequestDto dto);
        void SendNotificationFcm(NotificationRequestDto dto);

    }
}
