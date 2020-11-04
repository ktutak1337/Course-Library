using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Author
{
    public class DeleteAuthor : ICommand
    {
        public Guid Id { get; set; }
    }
}
