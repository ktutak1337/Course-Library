using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Commands.Course.Handlers
{
    public class DeleteCourseHandler : ICommandHandler<DeleteCourse>
    {
        private readonly ICoursesRepository _coursesRepository;

        public DeleteCourseHandler(ICoursesRepository coursesRepository) 
            => _coursesRepository = coursesRepository;

        public async Task HandleAsync(DeleteCourse command)
        {
            if(await _coursesRepository.ExistsAsync(command.Id))
            {
                throw new CourseNotFoundException(command.Id);
            }

            await _coursesRepository.DeleteAsync(command.Id);
        }
    }
}
