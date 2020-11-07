using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Category
{
    public class UpdateCategory : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
