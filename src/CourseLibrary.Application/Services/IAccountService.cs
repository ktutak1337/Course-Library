using System.Threading.Tasks;
using CourseLibrary.Application.Commands.Identity;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Services
{
    public interface IAccountService
    {
        Task<AuthDto> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
        Task ChangePasswordAsync(ChangePassword command);
    }
}
