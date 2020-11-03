using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Commands.WriteModels;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Commands.Course.Handlers
{
    public class CourseUpdateHandler : ICommandHandler<CourseUpdate>
    {
        private readonly ICoursesRepository _coursesRepository;

        public CourseUpdateHandler(ICoursesRepository coursesRepository) 
            => _coursesRepository = coursesRepository;

        public async Task HandleAsync(CourseUpdate command)
        {
            var existingCourse = await _coursesRepository.GetAsync(command.Id);
            
            if(existingCourse is null)
            {
                throw new CourseNotFoundException(command.Id);
            }

            var course = new Core.Aggregates.Course(command.Id, command.Name, command.Description, command.Category, 
                existingCourse.CreatedAt, command.Modules.AsEntities(), command.Authors.AsEntities());

            existingCourse.Update(course);

            await _coursesRepository.UpdateAsync(existingCourse);
        }
    }
}
