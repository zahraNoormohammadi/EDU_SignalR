using Microsoft.AspNetCore.SignalR;
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
    }
}
