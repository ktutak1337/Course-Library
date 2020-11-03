using System;
using System.Collections.Generic;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Commands.WriteModels;

namespace CourseLibrary.Application.Commands.Course
{
    public class CreateCourse : ICommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IEnumerable<ModuleWriteModel> Modules { get; set; }
        public IEnumerable<AuthorWriteModel> Authors { get; set; }
    }
}
