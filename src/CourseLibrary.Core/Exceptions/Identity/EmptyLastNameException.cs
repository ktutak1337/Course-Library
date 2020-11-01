using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmptyLastNameException : DomainException
    {
        public override string Code { get; } = "empty_last_name";
        public Guid UserId { get; }

        public EmptyLastNameException(Guid userId) 
            : base($"Empty last name defined for the user with id: '{userId}'.")
                => UserId = userId;
    }
}
