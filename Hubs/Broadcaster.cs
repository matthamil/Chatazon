using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Chatazon.Models;

namespace Chatazon.Hubs
{
    public class Broadcaster : Hub<IBroadcaster>
    {
        public override Task OnConnected()
        {
            // Set connection id for just connected client only
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }

        // Server side methods called from client
        public Task Subscribe(string chatroom)
        {
            return Groups.Add(Context.ConnectionId, chatroom.ToString());
        }

        public Task Unsubscribe(string chatroom)
        {
            return Groups.Remove(Context.ConnectionId, chatroom.ToString());
        }
    }

    // Client side methods to be invoked by Broadcaster Hub
    public interface IBroadcaster
    {
        Task SetConnectionId(string connectionId);
        Task AddChatMessage(MessageViewModel message);
    }
}