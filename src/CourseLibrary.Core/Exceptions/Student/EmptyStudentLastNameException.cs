using System;

namespace CourseLibrary.Core.Exceptions.Student
{
    public class EmptyStudentLastNameException : DomainException
    {
        public override string Code { get; } = "empty_student_last_name";
        public Guid StudentId { get; }
        public Guid UserId { get; }

        public EmptyStudentLastNameException(Guid studentId, Guid userId) 
            : base($"Empty first name defined for the student with ID: '{studentId}' - userId: '{userId}'.")
                => (StudentId, UserId) = (studentId, userId);
    }
}
