using System.Collections.Generic;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Queries.Identity
{
    public class GetUsers : IQuery<IEnumerable<UserDto>> { }
}
