using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Repositories;
using System;
using CourseLibrary.Application.Commands.WriteModels;

namespace CourseLibrary.Application.Commands.Course.Handlers
{
    public class CreateCourseHandler : ICommandHandler<CreateCourse>
    {
        private readonly ICoursesRepository _coursesRepository;

        public CreateCourseHandler(ICoursesRepository coursesRepository) 
            => _coursesRepository = coursesRepository;

        public async Task HandleAsync(CreateCourse command)
        {
            if(await _coursesRepository.ExistsAsync(command.Id))
            {
                throw new CourseNotFoundException(command.Id);
            }

            var course = new Core.Aggregates.Course(command.Id, command.Name, command.Description, command.Category, 
                DateTime.UtcNow, command.Modules.AsEntities(), command.Authors.AsEntities());
                    
            await _coursesRepository.AddAsync(course);
        }
    }
}
