using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Application.Services;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Commands.Student.Handlers
{
    public class CreateStudentHandler : ICommandHandler<CreateStudent>
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IUsersService _usersService;

        public CreateStudentHandler(IStudentsRepository studentsRepository, IUsersService usersService)
            => (_studentsRepository, _usersService) = (studentsRepository, usersService);

        public async Task HandleAsync(CreateStudent command)
        {
            var user = await _usersService.GetAsync(command.UserId);

            if(!(user is null))
            {
                throw new UserAlreadyExistsException(command.UserId);
            }
            
            var student = await _studentsRepository.GetAsync(command.UserId);
            
            if(!(student is null))
            {
                throw new StudentAlreadyExistsException(command.UserId);
            }

            student = new Core.Aggregates.Student(user.Id, user.FirstName, user.LastName, DateTime.UtcNow, null);

            await _studentsRepository.AddAsync(student);
        }
    }
}
