using System;

namespace CourseLibrary.Application.Exceptions
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public override string Code { get; } = "user_already_exists";
        public Guid UserId { get; }

        public UserAlreadyExistsException(Guid userId) 
            : base($"User with ID: '{userId}' already exists.") 
                => UserId = userId;
    }
}
