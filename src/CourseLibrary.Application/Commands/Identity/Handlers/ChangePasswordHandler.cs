using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Identity.Handlers
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IAccountService _accountService;

        public ChangePasswordHandler(IAccountService accountService) 
            => _accountService = accountService;

        public async Task HandleAsync(ChangePassword command) 
            => await _accountService.ChangePasswordAsync(command);
    }
}
