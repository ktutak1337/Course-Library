using System;

namespace CourseLibrary.Core.Exceptions.Identity
{
    public class EmptyEmailAddressException : DomainException
    {
        public override string Code { get; } = "empty_email_address";
        public Guid UserId { get; }

        public EmptyEmailAddressException(Guid userId) 
            : base($"Empty email address defined for the user with id: '{userId}'.")
                => UserId = userId;
    }
}
