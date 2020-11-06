using System;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Author;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;
using CourseLibrary.Application.Services.Identity;
using CourseLibrary.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [Allow(Role.Admin)]
    public class AuthorsController : BaseController
    {
        public AuthorsController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetAuthor query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetAuthors query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost]
        public async Task<IActionResult> Post(CreateAuthor command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateAuthor command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteAuthor command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
