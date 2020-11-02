using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmptyPasswordException : DomainException
    {
        public override string Code { get; } = "empty_password";
        public Guid UserId { get; }

        public EmptyPasswordException(Guid userId) 
            : base($"Empty password defined for the user with id: '{userId}'.")
                => UserId = userId;
    }
}
