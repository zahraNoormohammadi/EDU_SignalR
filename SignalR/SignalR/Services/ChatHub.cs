using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR.Contracts;
using SignalR.Models;

namespace SignalR.Services
{
    public class ChatHub : Hub<IMessageHubClient>//هاب اصلی سیگنال میباشد که میتوان امضا متد ها را به آن داد
    {
        /// <summary>
        /// فقط این متد SendAsync پیاده سازی شده است
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task SendAsync( MessageModel model)
            => await Clients.All.SendAsync( model);

        public async Task ReceiveAsync(MessageModel model)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:5170/Chat", options => {
                options.Transports = HttpTransportType.WebSockets;
            }).WithAutomaticReconnect().Build();
            await connection.StartAsync();
         
            connection.On<string,string,string>("ReceiveAsync",
                (user, message,date) => { Clients.All.SendAsync(model).GetAwaiter();

            });
            await Clients.All.ReceiveAsync(model);
        }
    }
}
