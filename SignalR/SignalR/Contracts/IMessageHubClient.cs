namespace SignalR.Contracts
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);
    }
}
