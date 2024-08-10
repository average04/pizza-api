namespace Pizza.API.Controllers.Base;

[ApiController]
[Produces("application/json")]
[Route("api/v1/")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}