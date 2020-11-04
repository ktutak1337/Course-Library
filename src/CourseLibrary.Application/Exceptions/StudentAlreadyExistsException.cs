using System;

namespace CourseLibrary.Application.Exceptions
{
    public class StudentAlreadyExistsException : ApplicationException
    {
        public override string Code { get; } = "student_already_exists";
        public Guid UserId { get; }

        public StudentAlreadyExistsException(Guid userId) 
            : base($"Student with userID: '{userId}' already exists.") 
                => UserId = userId;
    }
}
