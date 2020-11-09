using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class RevokeRefreshToken : ICommand
    {
        public string RefreshToken { get; set; }
    }
}
