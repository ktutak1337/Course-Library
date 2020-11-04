using System;

namespace CourseLibrary.Core.Exceptions.Student
{
    public class EmptyStudentFirstNameException : DomainException
    {
        public override string Code { get; } = "empty_student_first_name";
        public Guid UserId { get; }

        public EmptyStudentFirstNameException(Guid userId) 
            : base($"Empty first name defined for the student with userID: '{userId}'.")
                => UserId = userId;
    }
}
