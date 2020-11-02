using System;
using Convey.CQRS.Commands;
using CourseLibrary.Core;

namespace CourseLibrary.Application.Commands.Identity
{
    public class SignUp : ICommand
    {
        public Guid Id { get; set; } = new UserId(Guid.NewGuid());
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
