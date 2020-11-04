using System;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Queries
{
    public class GetCourse : IQuery<CourseDto>
    {
        public Guid Id { get; set; }
    }
}
