using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Category
{
    public class CreateCategory : ICommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
