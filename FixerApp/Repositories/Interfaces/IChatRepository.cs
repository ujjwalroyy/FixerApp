using FixerApp.Models.Entities;

namespace FixerApp.Repositories.Interfaces
{
 
        public interface IChatRepository
        {
            void SaveMessage(ChatMessage message);
            List<ChatMessage> GetMessages(long senderId, long receiverId);
            List<ChatMessage> GetMessagesByJobId(long jobId);
            List<ChatMessage> FindUnreadMessages(long senderId, long receiverId);
            Dictionary<long, long> GetUnreadCountByUser(long userId);
            void MarkMessagesAsRead(long senderId, long receiverId);
        }
    }
