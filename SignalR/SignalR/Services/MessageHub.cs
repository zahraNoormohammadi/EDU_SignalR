using Microsoft.AspNetCore.SignalR;
using SignalR.Contracts;

namespace SignalR.Services
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        => await Clients.All.SendOffersToUser(message);

    }
}
