using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        List<Notification> FindByUserIdOrderByCreatedAtDesc(long userId);
    }
}
