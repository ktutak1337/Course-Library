using System;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Course;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    public class CoursesController : BaseController
    {
        public CoursesController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetCourse query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetCourses query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCourse command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, command.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CourseUpdate command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteCourse command)
        {
            command.Id = id;

            await Dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}