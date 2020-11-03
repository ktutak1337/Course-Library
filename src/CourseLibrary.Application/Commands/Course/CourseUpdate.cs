using System;
using System.Collections.Generic;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Commands.WriteModels;

namespace CourseLibrary.Application.Commands.Course
{
    public class CourseUpdate : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IEnumerable<ModuleWriteModel> Modules { get; set; }
        public IEnumerable<AuthorWriteModel> Authors { get; set; }
    }
}
