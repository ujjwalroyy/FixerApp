using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Notification> FindByUserIdOrderByCreatedAtDesc(long userId)
        {
            return _context.Notifications
                           .Where(n => n.UserId == userId)
                           .OrderByDescending(n => n.CreatedAt)
                           .ToList();
        }
    }
}
