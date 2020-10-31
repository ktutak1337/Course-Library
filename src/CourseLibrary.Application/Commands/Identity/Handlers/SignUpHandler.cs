using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Identity.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IAccountService _accountService;

        public SignUpHandler(IAccountService accountService) 
            => _accountService = accountService;

        public async Task HandleAsync(SignUp command)
            => await _accountService.SignUpAsync(command);
    }
}
