using Application.Features.Clients.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateClientCommand clientCommand)
        {
            return Ok(await Mediator.Send(clientCommand));
        }
    }
}