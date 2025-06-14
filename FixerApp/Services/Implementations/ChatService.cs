using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Repositories.Interfaces;
using FixerApp.Services.Interfaces;

namespace FixerApp.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;

        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }

        public ChatMessageDto SendMessage(ChatMessageDto dto)
        {
            var message = MapDtoToEntity(dto);
            _repository.SaveMessage(message);
            return MapEntityToDto(message);
        }

        public async Task<ChatMessageDto> SendMessageAsync(ChatMessageDto dto)
        {
            // In-memory async simulation
            return await Task.Run(() => SendMessage(dto));
        }

        public List<ChatMessageDto> GetChatByJobId(long jobId)
        {
            return _repository.GetMessagesByJobId(jobId)
                .Select(MapEntityToDto)
                .ToList();
        }

        public List<ChatMessageDto> GetMessages(long senderId, long receiverId)
        {
            return _repository.GetMessages(senderId, receiverId)
                .Select(MapEntityToDto)
                .ToList();
        }

        public Dictionary<long, long> GetUnreadMessageCounts(long userId)
        {
            return _repository.GetUnreadCountByUser(userId);
        }

        public void MarkMessagesAsRead(long senderId, long receiverId)
        {
            _repository.MarkMessagesAsRead(senderId, receiverId);
        }

        private ChatMessage MapDtoToEntity(ChatMessageDto dto)
        {
            return new ChatMessage
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                JobId = dto.JobId,
                Text = dto.Text,
                FileUrl = dto.FileUrl,
                SentAt = dto.Timestamp
            };
        }

        private ChatMessageDto MapEntityToDto(ChatMessage msg)
        {
            return new ChatMessageDto
            {
                SenderId = msg.SenderId,
                ReceiverId = msg.ReceiverId,
                JobId = msg.JobId,
                Text = msg.Text,
                FileUrl = msg.FileUrl,
                Timestamp = msg.SentAt
            };
        }

       
    }
}
