using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Author
{
    public class CreateAuthor : ICommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
