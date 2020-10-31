using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Core;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Exceptions.Identity;
using CourseLibrary.Core.Repositories;

namespace CourseLibrary.Application.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtBroker _jwtBroker;
        private static readonly Regex EmailRegex = new Regex(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public AccountService(IUsersRepository usersRepository, IPasswordService passwordService, IJwtBroker jwtBroker)
            => (_usersRepository, _passwordService, _jwtBroker) = (usersRepository, passwordService, jwtBroker);

        public async Task<AuthDto> SignInAsync(SignIn command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            }

            var user = await _usersRepository.GetAsync(command.Email);

            if(user is null || !_passwordService.Verify(user.Password, command.Password))
            {
                throw new InvalidCredentialsException();
            }

            return _jwtBroker.CreateToken(user.Id, user.Role);
        }

        public async Task SignUpAsync(SignUp command)
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
