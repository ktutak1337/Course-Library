using System;
using System.Collections.Generic;
using CourseLibrary.Application.DTOs.Identity;

namespace CourseLibrary.Application.Services
{
    public interface IJwtBroker
    {
         AuthDto CreateToken(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}
