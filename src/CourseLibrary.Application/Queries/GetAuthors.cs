using System.Collections.Generic;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;

namespace CourseLibrary.Application.Queries
{
    public class GetAuthors : IQuery<IEnumerable<AuthorDto>> { }
}
