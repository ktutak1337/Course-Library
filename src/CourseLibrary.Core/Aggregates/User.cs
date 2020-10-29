using System;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.Identity;

namespace CourseLibrary.Core.Aggregates
{
    public class User : AggregateRoot
    {
        public UserId Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(UserId id, string email, string password, string role, bool isActive = true, DateTime? createdAt = null, DateTime? updatedAt = null)
        {
            Id = id;       
            SetEmail(email.ToLowerInvariant());
            SetPassword(password);
            SetRole(role.ToLowerInvariant());
            IsActive = isActive;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            UpdatedAt = updatedAt ?? DateTime.UtcNow;
        }

        private void SetEmail(string email)
        {
            if (email.IsEmpty())
            {
                throw new InvalidEmailException(email);
            }
        }

        private void SetPassword(string password)
        {
            if (password.IsEmpty())
            {
                throw new InvalidCredentialsException();
            }
        }

        private void SetRole(string role)
        {
            if (!Types.Role.IsValid(role))
            {
                throw new InvalidRoleException(role);
            }
        }
    }
}
