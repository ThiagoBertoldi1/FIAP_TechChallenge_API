using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.API.Controllers.BaseController;
using TechChallenge.Domain.Commands.ContactCommands.Create;
using TechChallenge.Domain.Entities;
using TechChallenge.Infra.Responses;

namespace TechChallenge.API.Controllers;

public class ContactController(IMediator mediator) : APIControllerBase(mediator)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<Contact>))]
    public async Task<IActionResult> Create([FromBody] CreateContactCommand command, CancellationToken cancellationToken)
        => ReturnResponse(await _mediator.Send(command, cancellationToken));
}
