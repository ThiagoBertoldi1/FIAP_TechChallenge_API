using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TechChallenge.Infra.Responses;

namespace TechChallenge.API.Controllers.BaseController;

[ApiController]
[Route("api/[controller]")]

public class APIControllerBase(IMediator mediator) : ControllerBase
{
    protected IMediator _mediator = mediator;

    protected IActionResult ReturnResponse<T>(ResponseBase<T> response)
    {
        if (response.StatusCode != HttpStatusCode.OK)
            return BadRequest(response);

        return Ok(response);
    }
}
