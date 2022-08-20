using Employee_CRUD.Data;
using Employee_CRUD.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Employee_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadCastController : ControllerBase
    {
        private readonly IHubContext<MessageHub, IMessageHubClient> _messageHub;

        public BroadCastController(IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            _messageHub = messageHub;
        }

        //using SignalR
        //[HttpPost("SendMessage")]
        //public async Task SendMessage()
        //{
        //    await _messageHub.Clients.All.SendMessage("hiiiii");
        //}
    }
}
