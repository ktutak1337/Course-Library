using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class RefreshAccessToken : ICommand
    {
        public string RefreshToken { get; set; }
    }
}
