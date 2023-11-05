using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR.Contracts;
using SignalR.Services;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        #region props
        private readonly IHubContext<MessageHub, IMessageHubClient> _messageHub;
        #endregion

        #region ctor

        public HubController(IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
        }
        #endregion

        #region publicMethods
        [HttpGet("SendMessage")]
        public async Task<string> SendMessage()
        {
            var message = new List<string>();
            message.Add(JsonConvert.SerializeObject(new TestModel(){Id = 1,FirstName = "M",LastName = "Z"}));//when send model
            message.Add("sample text");//when send text
            await _messageHub.Clients.All.SendOffersToUser(message);
            return "Message is sent!";
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
