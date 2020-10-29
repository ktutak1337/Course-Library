using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class SignIn : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
