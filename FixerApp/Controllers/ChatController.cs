using FixerApp.Hubs;
using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService, IHubContext<ChatHub> hubContext)
        {
            _chatService = chatService;
            _hubContext = hubContext;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Text))
                return BadRequest("Message content cannot be empty.");

            var savedMessage = await _chatService.SendMessageAsync(dto);

            await _hubContext.Clients.User(dto.ReceiverId.ToString())
                .SendAsync("ReceiveMessage", savedMessage);

            return Ok(savedMessage);
        }

        [HttpGet("job/{jobId}")]
        public IActionResult GetChatByJobId(long jobId)
        {
            var messages = _chatService.GetChatByJobId(jobId);
            return Ok(messages);
        }

        [HttpGet("messages")]
        public IActionResult GetMessages(long senderId, long receiverId)
        {
            var messages = _chatService.GetMessages(senderId, receiverId);
            return Ok(messages);
        }

        [HttpPost("mark-as-read")]
        public IActionResult MarkMessagesAsRead(long senderId, long receiverId)
        {
            _chatService.MarkMessagesAsRead(senderId, receiverId);
            return Ok(new { message = "Marked as read" });
        }

        [HttpGet("unread-count/{userId}")]
        public IActionResult GetUnreadMessageCounts(long userId)
        {
            var counts = _chatService.GetUnreadMessageCounts(userId);
            return Ok(counts);
        }
    }
}
