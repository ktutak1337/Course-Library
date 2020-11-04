using System;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Queries
{
    public class GetStudent : IQuery<StudentDto>
    {
        public Guid UserId { get; set; }
    }
}
