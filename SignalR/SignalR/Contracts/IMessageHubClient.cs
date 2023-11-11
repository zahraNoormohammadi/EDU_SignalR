namespace SignalR.Contracts
{
    public interface IMessageHubClient
    {
        /// <summary>
        /// می توان انواع امضا متد ها را در یک اینترفیس گذاشت ولی در کلاس های متفاوات هر کدام را که لازم است پیاده سازی نمود
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMessageToUser(List<string> message);
        Task SendAsync(string user,string message);
    }
}
