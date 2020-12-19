using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Exceptions;
using CourseLibrary.Core.Exceptions.Identity;

namespace CourseLibrary.Application.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IUsersService _usersService;
        private readonly IPasswordService _passwordService;
        private readonly IJwtBroker _jwtBroker;
        private readonly IRefreshTokenService _refreshTokenService;
        private static readonly Regex EmailRegex = new Regex(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public AccountService(IUsersService usersService, IPasswordService passwordService, IJwtBroker jwtBroker, IRefreshTokenService refreshTokenService)
            => (_usersService, _passwordService, _jwtBroker, _refreshTokenService) = (usersService, passwordService, jwtBroker, refreshTokenService);

        public async Task<AuthDto> SignInAsync(SignIn command)
        {
            if (!EmailRegex.IsMatch(command.Email))
            {
                throw new InvalidEmailException(command.Email);
            }

            var user = await _usersService.GetAsync(command.Email);

            if(user is null || !_passwordService.Verify(user.Password, command.Password))
            {
                throw new InvalidCredentialsException();
            }

            var auth = _jwtBroker.CreateToken(user.Id, user.Role);
            auth.RefreshToken = await _refreshTokenService.CreateAsync(user.Id);

            return auth;
        }

        public async Task SignUpAsync(SignUp command)
            => await _usersService.CreateAsync(command);

        public async Task ChangePasswordAsync(ChangePassword command)
        {
            var user = await _usersService.GetAsync(command.UserId);

            if(user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }
            
            if (!_passwordService.Verify(user.Password, command.CurrentPassword))
            {
                throw new InvalidCredentialsException();
            }
            
            user.Password = _passwordService.HashPassword(command.NewPassword);

            await _usersService.UpdateAsync(user);
        }
    }
}
