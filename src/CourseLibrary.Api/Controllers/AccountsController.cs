using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.Queries.Identity;
using CourseLibrary.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    public class AccountsController : BaseController
    {
        public AccountsController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetUser query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(SignUp command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }
    }
}
