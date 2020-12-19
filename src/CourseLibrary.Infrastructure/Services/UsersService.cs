using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Application.Services;
using CourseLibrary.Core;
using CourseLibrary.Core.Exceptions.Identity;
using CourseLibrary.Core.Repositories;
using CourseLibrary.Infrastructure.Exceptions;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents.Identity;

namespace CourseLibrary.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoRepository<UserDocument, Guid> _usersRepository;
        private readonly IStudentsRepository _studentsRepository; 
        private readonly IPasswordService _passwordService;

        private static readonly Regex EmailRegex = new Regex(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public UsersService(IMongoRepository<UserDocument, Guid> repository, IStudentsRepository studentsRepository, IPasswordService passwordService)
            => (_usersRepository, _studentsRepository, _passwordService) = (repository, studentsRepository, passwordService);

        public async Task<UserDto> GetAsync(Guid id)
            => (await _usersRepository.GetAsync(id))
                ?.AsDto();

        public async Task<UserDto> GetAsync(string email)
            => (await _usersRepository.GetAsync(document => document.Email == email))
                ?.AsDto();

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
            => (await _usersRepository.FindAsync(_ => true))
                ?.Select(order => order.AsDto());

        public async Task CreateAsync(SignUp command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            }
            
            if(await _usersRepository.ExistsAsync(user => user.Email == command.Email))
            {
                throw new EmailAddressInUseException(command.Email);
            }

            var hashedPassword = _passwordService.HashPassword(command.Password);
            var role = command.Role.IsEmpty() ? "user" : command.Role.ToLowerInvariant();

            var user = new UserDto
            {
                Id = command.Id, 
                FirstName = command.FirstName,
                LastName = command.LastName, 
                Email = command.Email,
                Password = hashedPassword, 
                Role = role,
                CreatedAt = DateTime.UtcNow
            };
            
            await _usersRepository.AddAsync(user.AsDocument());
        }

        public async Task UpdateAsync(UpdateUser command)
        {
            var user = await _usersRepository.GetAsync(command.Id);
            
            if(user is null)
            {
                throw new UserNotFoundException(command.Id);
            }

            var student = await _studentsRepository.GetAsync(command.Id);

            if(student is null)
            {
                throw new StudnetNotFoundException(command.Id);
            }

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Email = command.Email;
            user.Role = command.Role;

            student.UpdateDetails(command.FirstName, command.LastName);

            await _usersRepository.UpdateAsync(user);
            await _studentsRepository.UpdateAsync(student);
        }

        public async Task UpdateAsync(UserDto user)
            => await _usersRepository.UpdateAsync(user.AsDocument());

        public async Task DeleteAsync(Guid id)
            => await _usersRepository.DeleteAsync(id);
    }
}
