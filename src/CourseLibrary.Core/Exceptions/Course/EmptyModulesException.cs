using System;

namespace CourseLibrary.Core.Exceptions.Course
{
    public class EmptyModulesException : DomainException
    {
        public override string Code { get; } = "empty_modules";
        public Guid CourseId { get; }
        
        public EmptyModulesException(Guid courseId) 
            : base($"An empty collection of modules defined for course with ID: '{courseId}'.")
                => CourseId = courseId;
    }
}
