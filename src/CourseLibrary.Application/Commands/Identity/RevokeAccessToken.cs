using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class RevokeAccessToken : ICommand
    {
        public string AccessToken { get; set; }
    }
}
