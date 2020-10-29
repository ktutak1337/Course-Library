using System;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Queries.Identity
{
    public class GetUser : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
