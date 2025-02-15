using MediatR;

using Microsoft.AspNetCore.Mvc;

using Veil.Application.Message.Commands;
using Veil.Application.Message.Queries;

namespace Veil.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController(IMediator mediator) : ControllerBase
{
    [HttpGet("test")]
    public async Task<Guid> Test([FromQuery] string text)
    {
        var command = new CreateMessageCommand
        {
            Text = text
        };

        return await mediator.Send(command);
    }

    [HttpGet("all")]
    public async Task<object> All()
    {
        var query = new GetMessagesQuery();
        return await mediator.Send(query);
    }
}
