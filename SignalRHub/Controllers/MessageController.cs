using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Controllers
{
    public class MessageController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("[controller]/send/{groupId}")]
        public async Task<IActionResult> Post(string groupId, [FromBody]Message msg)
        {
           try
            {
                await _hubContext.Clients.Group(groupId).BroadcastMessage(msg.Type, msg.Payload);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
