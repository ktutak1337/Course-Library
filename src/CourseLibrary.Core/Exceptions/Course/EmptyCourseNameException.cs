using System;

namespace CourseLibrary.Core.Exceptions.Course
{
    public class EmptyCourseNameException : DomainException
    {
        public override string Code { get; } = "empty_course_name";
        public Guid CourseId { get; }
        
        public EmptyCourseNameException(Guid courseId) 
            : base($"Empty name defined for course with ID: '{courseId}'.")
                => CourseId = courseId;
    }
}
