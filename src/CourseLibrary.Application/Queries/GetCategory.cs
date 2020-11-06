using System;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Queries
{
    public class GetCategory : IQuery<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
