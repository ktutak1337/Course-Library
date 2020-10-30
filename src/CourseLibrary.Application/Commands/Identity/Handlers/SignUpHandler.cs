using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;
using CourseLibrary.Core;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Exceptions.Identity;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Commands.Identity.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordService _passwordService;

        private static readonly Regex EmailRegex = new Regex(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public SignUpHandler(IUsersRepository usersRepository, IPasswordService passwordService)
            => (_usersRepository, _passwordService) = (usersRepository, passwordService);

        public async Task HandleAsync(SignUp command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            }

            var user = await _usersRepository.GetAsync(command.Email);

            if(user != null)
            {
                throw new EmailAddressInUseException(command.Email);
            }

            var hashedPassword = _passwordService.HashPassword(command.Password);
            var role = command.Role.IsEmpty() ? "user" : command.Role.ToLowerInvariant();

            user = new User(command.Id, command.Email, hashedPassword, role, createdAt: DateTime.UtcNow);
            
            await _usersRepository.AddAsync(user);
        }
    }
}
