using System;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.Identity;

namespace CourseLibrary.Core.Aggregates
{
    public class User : AggregateRoot
    {
        public UserId Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { }
        
        public User(UserId id, string firstName, string lastName, string email, string password, string role, DateTime createdAt, bool isActive = true)
        {
            Id = id;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email.ToLowerInvariant());
            SetPassword(password);
            SetRole(role.ToLowerInvariant());
            IsActive = isActive;
            CreatedAt = createdAt;
        }

        private void SetFirstName(string firstName)
        {
            if (firstName.IsEmpty())
            {
                throw new EmptyFirstNameException(Id);
            }

            FirstName = firstName;
        }

        private void SetLastName(string lastName)
        {
            if (lastName.IsEmpty())
            {
                throw new EmptyLastNameException(Id);
            }

            LastName = lastName;
        }

        private void SetEmail(string email)
        {
            if (email.IsEmpty())
            {
                throw new EmptyEmailAddressException(Id);
            }

            Email = email;
        }

        private void SetPassword(string password)
        {
            if (password.IsEmpty())
            {
                throw new EmptyPasswordException(Id);
            }

            Password = password;
        }

        private void SetRole(string role)
        {
            if (!Types.Role.IsValid(role))
            {
                throw new InvalidRoleException(role);
            }

            Role = role;
        }

        public void ChangePassword(string password)
        {
            SetPassword(password);
        }
    }
}
