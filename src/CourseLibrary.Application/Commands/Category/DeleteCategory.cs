using System;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Category
{
    public class DeleteCategory : ICommand
    {
        public Guid Id { get; set; }
    }
}
