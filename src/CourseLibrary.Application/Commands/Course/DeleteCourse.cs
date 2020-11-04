using System;
using System.ComponentModel.DataAnnotations;
using Convey.CQRS.Commands;

namespace CourseLibrary.Application.Commands.Course
{
    public class DeleteCourse : ICommand
    {
        public Guid Id { get; set; }
    }
}
