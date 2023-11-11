using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR.Contracts;
using SignalR.Services;

namespace SignalR.Controllers
{
    [Route("Hub")]
    [ApiController]
    public class HubController : ControllerBase
    {
        #region props
        private readonly IHubContext<MessageHub, IMessageHubClient> _messageHub;
        private readonly IHubContext<ChatHub, IMessageHubClient> _chatHub;
        #endregion

        #region ctor

        public HubController(IHubContext<MessageHub, IMessageHubClient> messageHub, IHubContext<ChatHub, IMessageHubClient> chatHub)
        {
            _messageHub = messageHub;
            _chatHub = chatHub;
        }
        #endregion

        #region publicMethods

        [HttpGet("SendMessage")]
        public async Task<string> SendMessage()
        {
            var message = new List<string>();
            message.Add(JsonConvert.SerializeObject(new TestModel() { Id = 1, FirstName = "M", LastName = "Z" }));//when send model
            message.Add("sample text");//when send text
            await _messageHub.Clients.All.SendMessageToUser(message);
           
            return "Message is sent!";
        }
        [HttpGet("SendText")]
        public async Task<string> SendText()
        {
            await _chatHub.Clients.All.SendAsync( "Zamani", "Hello");
            return "Text is sent!";
        }
        #endregion
    }

    public class TestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
