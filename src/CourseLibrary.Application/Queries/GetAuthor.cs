using System;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Queries
{
    public class GetAuthor : IQuery<AuthorDto>
    {
        public Guid Id { get; set; }
    }
}
