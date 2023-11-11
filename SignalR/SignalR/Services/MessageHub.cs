using Microsoft.AspNetCore.SignalR;
using SignalR.Contracts;

namespace SignalR.Services
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendMessageToUser(List<string> message)
        => await Clients.All.SendMessageToUser(message);
       
    }
}
