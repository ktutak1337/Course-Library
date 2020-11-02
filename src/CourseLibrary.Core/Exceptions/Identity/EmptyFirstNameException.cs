using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmptyFirstNameException : DomainException
    {
        public override string Code { get; } = "empty_first_name";
        public Guid UserId { get; }

        public EmptyFirstNameException(Guid userId) 
            : base($"Empty first name defined for the user with id: '{userId}'.")
                => UserId = userId;
    }
}
