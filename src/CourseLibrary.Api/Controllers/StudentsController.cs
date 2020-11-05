using System;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Student;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;
using CourseLibrary.Application.Services.Identity;
using CourseLibrary.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.Api.Controllers
{
    [Allow(Role.Admin, Role.User)]
    public class StudentsController : BaseController
    {
        public StudentsController(IDispatcher dispatcher) 
            : base(dispatcher) { }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] GetStudent query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] GetStudents query) 
            => Select(await Dispatcher.QueryAsync(query));

        [HttpPost("{userId}")]
        public async Task<IActionResult> Post(CreateStudent command)
        {
            await Dispatcher.SendAsync(command);
        
            return CreatedAtAction(nameof(Get), new { UserId = command.UserId }, command.UserId);
        } 
    }
}
