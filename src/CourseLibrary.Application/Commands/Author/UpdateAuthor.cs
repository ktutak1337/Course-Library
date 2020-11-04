using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Author
{
    public class UpdateAuthor : ICommand
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
