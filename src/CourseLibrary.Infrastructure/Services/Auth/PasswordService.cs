using CourseLibrary.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace CourseLibrary.Infrastructure.Services.Auth
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<IPasswordService> _passwordHasher;

        public PasswordService(IPasswordHasher<IPasswordService> passwordHasher) 
            => _passwordHasher = passwordHasher;

        public bool Verify(string hash, string password)
            => _passwordHasher.VerifyHashedPassword(this, hash, password) == PasswordVerificationResult.Success;

        public string HashPassword(string password)
            => _passwordHasher.HashPassword(this, password);
    }
}
