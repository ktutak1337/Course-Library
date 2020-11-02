using System;

namespace CourseLibrary.Core.Exceptions.Course
{
    public class EmptyAuthorsException : DomainException
    {
        public override string Code { get; } = "empty_authors";
        public Guid CourseId { get; }
        
        public EmptyAuthorsException(Guid courseId) 
            : base($"An empty collection of authors defined for course with ID: '{courseId}'.")
                => CourseId = courseId;
    }
}
