using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using SignalR.Contracts;

namespace SignalR.Services
{
    public class ChatHub : Hub<IMessageHubClient>//هاب اصلی سیگنال میباشد که میتوان امضا متد ها را به آن داد
    {
        /// <summary>
        /// فقط این متد SendAsync پیاده سازی شده است
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendAsync( string user, string message)
            => await Clients.All.SendAsync( user, message);

        public async Task ReceiveAsync(string user, string message)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:5170/Chat", options => {
                options.Transports = HttpTransportType.WebSockets;
            }).WithAutomaticReconnect().Build();
            await connection.StartAsync();
         
            connection.On<string,string>("ReceiveAsync",
                (user, message) => { Clients.All.SendAsync(user, message).GetAwaiter();


            });
            await Clients.All.ReceiveAsync(user, message);
        }
    }
}
