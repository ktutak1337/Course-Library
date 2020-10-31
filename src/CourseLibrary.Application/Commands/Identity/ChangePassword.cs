using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class ChangePassword : ICommand
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; } 
    }
}
