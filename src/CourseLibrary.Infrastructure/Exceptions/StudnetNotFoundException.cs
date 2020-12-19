using System;

namespace CourseLibrary.Infrastructure.Exceptions
{
    public class StudnetNotFoundException : InfrastructureException
    {
        public override string Code { get; } = "student_not_found";
        public Guid StudentId { get; }

        public StudnetNotFoundException(Guid studentId)
            : base($"Student with ID: '{studentId}' not found.") 
                => StudentId = studentId;
    }
}
