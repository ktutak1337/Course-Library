using System.Threading.Tasks;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        public Task HandleAsync(SignUp command)
        {
            throw new System.NotImplementedException();
        }
    }
}
