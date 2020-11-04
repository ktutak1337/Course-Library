using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Commands.Student.Handlers
{
    public class CreateStudentHandler : ICommandHandler<CreateStudent>
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IUsersRepository _usersRepository;

        public CreateStudentHandler(IStudentsRepository studentsRepository, IUsersRepository usersRepository)
            => (_studentsRepository, _usersRepository) = (studentsRepository, usersRepository);

        public async Task HandleAsync(CreateStudent command)
        {
            var user = await _usersRepository.GetAsync(command.UserId);

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
