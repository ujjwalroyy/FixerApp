using FixerApp.Hubs;
using FixerApp.Models.DTOs;
using FixerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/chatws")]
    public class ChatWebSocketController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatService _chatService;

        public ChatWebSocketController(IHubContext<ChatHub> hubContext, IChatService chatService)
        {
            _hubContext = hubContext;
            _chatService = chatService;
        }

        [HttpPost("send-ws")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto dto)
        {
            var saved = await _chatService.SendMessageAsync(dto);
            await _hubContext.Clients.User(saved.ReceiverId.ToString()).SendAsync("ReceiveMessage", saved);
            return Ok(saved);
        }

        [HttpGet("unread-count/{userId}")]
        public ActionResult<Dictionary<long, long>> GetUnreadCounts(long userId)
        {
            var result = _chatService.GetUnreadMessageCounts(userId);
            return Ok(result);
        }

        [HttpPost("mark-read")]
        public IActionResult MarkAsRead([FromBody] MarkReadDto dto)
        {
            _chatService.MarkMessagesAsRead(dto.SenderId, dto.ReceiverId);
            return Ok();
        }
    }
}
