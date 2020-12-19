using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Identity
{
    public class UpdateUser : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
