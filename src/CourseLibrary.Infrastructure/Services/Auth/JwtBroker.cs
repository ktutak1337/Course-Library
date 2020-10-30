using System;
using System.Collections.Generic;
using Convey.Auth;
using CourseLibrary.Application.DTOs.Identity;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Infrastructure.Services.Auth
{
    public class JwtBroker : IJwtBroker
    {
        private readonly IJwtHandler _jwtHandler;

        public JwtBroker(IJwtHandler jwtHandler) 
            => _jwtHandler = jwtHandler;

        public AuthDto CreateToken(Guid userId, string role, string audience = null, 
            IDictionary<string, IEnumerable<string>> claims = null)
        {
            var jwt = _jwtHandler.CreateToken(userId.ToString("N"), role, audience, claims);

            return new AuthDto
            {
                AccessToken = jwt.AccessToken,
                Role = jwt.Role,
                Expires = jwt.Expires
            };
        }
    }
}
