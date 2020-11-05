using System;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Course;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;
using CourseLibrary.Application.Services.Identity;
using CourseLibrary.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    public class CoursesController : BaseController
    {
        public CoursesController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetCourse query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] GetCourses query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost]
        [Allow(Role.Admin, Role.User)]
        public async Task<IActionResult> Post(CreateCourse command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        [HttpPut("{id}")]
        [Allow(Role.Admin, Role.User)]
        public async Task<IActionResult> Put(Guid id, CourseUpdate command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Allow(Role.Admin, Role.User)]
        public async Task<IActionResult> Delete(Guid id, DeleteCourse command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}