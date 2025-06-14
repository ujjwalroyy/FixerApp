using FixerApp.Models.DTOs;

namespace FixerApp.Services.Interfaces
{

    public interface IChatService
    {
        ChatMessageDto SendMessage(ChatMessageDto dto);
        Task<ChatMessageDto> SendMessageAsync(ChatMessageDto dto);
        List<ChatMessageDto> GetChatByJobId(long jobId);
        List<ChatMessageDto> GetMessages(long senderId, long receiverId);
        Dictionary<long, long> GetUnreadMessageCounts(long userId);
        void MarkMessagesAsRead(long senderId, long receiverId);
    }
}
