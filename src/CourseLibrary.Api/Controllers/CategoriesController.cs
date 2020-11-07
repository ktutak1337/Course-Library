using System;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Category;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;
using CourseLibrary.Application.Services.Identity;
using CourseLibrary.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetCategory query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetCategories query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Post(CreateCategory command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        [HttpPut("{id}")]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Put(Guid id, UpdateCategory command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Allow(Role.Admin)]
        public async Task<IActionResult> Delete(Guid id, DeleteCategory command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
