using Application.DTOs.Client;
using Application.Features.Clients.Commands;
using Application.Features.Clients.Queries.GetAll;
using Application.Features.Clients.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetClientAllParameter filter)
        {
            return Ok(await Mediator.Send(new GetClientAll { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                FirstName = filter.FirstName,
                LastName = filter.LastName
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await Mediator.Send(new GetClientById { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateClientCommand clientCommand)
        {
            return Ok(await Mediator.Send(clientCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateClient client)
        {
            var clientCommand = new UpdateClientCommand
            {
                Id = id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                DateBirth = client.DateBirth,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
            };

            return Ok(await Mediator.Send(clientCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var clientCommand = new DeleteClientCommand
            {
                Id = id,
            };

            return Ok(await Mediator.Send(clientCommand));
        }
    }
}