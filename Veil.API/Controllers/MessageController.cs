using MediatR;

using Microsoft.AspNetCore.Mvc;

using Veil.Application.Message.Commands;

namespace Veil.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("test")]
    public async Task<int> Test()
    {
        Console.WriteLine("hello");
        var command = new CreateMessageCommand
        {
            Text = "Hello there"
        };

        return await _mediator.Send(command);
    }
}
