using Microsoft.AspNetCore.SignalR;

namespace FixerApp.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"User connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public async Task SendMessageToUser(string receiverId, object message)
        {
            await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
        }

        public async Task BroadcastMessage(object message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
