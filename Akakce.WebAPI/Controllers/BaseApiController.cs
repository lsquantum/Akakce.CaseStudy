using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Akakce.WebAPI.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator = null!;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}
