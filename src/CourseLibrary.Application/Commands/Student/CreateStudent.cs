using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Student
{
    public class CreateStudent : ICommand
    {
        public Guid UserId { get; set; }        
    }
}
