using FixerApp.Data;
using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixrApp.Data;

namespace FixerApp.Repositories.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveMessage(ChatMessage message)
        {
            _context.ChatMessage.Add(message);
            _context.SaveChanges();
        }

        public List<ChatMessage> GetMessages(long senderId, long receiverId)
        {
            return _context.ChatMessage
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.SentAt)
                .ToList();
        }

        public List<ChatMessage> GetMessagesByJobId(long jobId)
        {
            return _context.ChatMessage
                .Where(m => m.JobId == jobId)
                .OrderBy(m => m.SentAt)
                .ToList();
        }

        public List<ChatMessage> FindUnreadMessages(long senderId, long receiverId)
        {
            return _context.ChatMessage
                .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId && !m.Read)
                .ToList();
        }

        public void MarkMessagesAsRead(long senderId, long receiverId)
        {
            var unread = FindUnreadMessages(senderId, receiverId);
            foreach (var msg in unread)
            {
                msg.Read = true;
            }
            _context.SaveChanges();
        }

        public Dictionary<long, long> GetUnreadCountByUser(long userId)
        {
            return _context.ChatMessage
                .Where(m => m.ReceiverId == userId && !m.Read)
                .GroupBy(m => m.SenderId)
                .ToDictionary(g => g.Key, g => (long)g.Count());
        }
    }
}
