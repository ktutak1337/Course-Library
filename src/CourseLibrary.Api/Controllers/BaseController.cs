using System;
using CourseLibrary.Application.Services;
using CourseLibrary.Core;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IDispatcher Dispatcher;
        protected Guid UserId
            => (User?.Identity?.Name).IsEmpty() 
                ? Guid.Empty 
                : Guid.Parse(User.Identity.Name);

        protected BaseController(IDispatcher dispatcher) 
            => Dispatcher = dispatcher;

        protected IActionResult Select<TData>(TData data)
            where TData: class
                => data is null ? NotFound()
                                : Ok(data) as IActionResult;
    }
}
