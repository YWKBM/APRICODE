using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using App.Metrics.Counter;
using App.Metrics;

namespace Games.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMetrics _metrics;
        
        protected IMetrics metrics =>
            _metrics ??= HttpContext.RequestServices.GetService<IMetrics>();

        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
