using System;

namespace CourseLibrary.Core.Exceptions.Course
{
    public class EmptyCourseDescriptionException : DomainException
    {
        public override string Code { get; } = "empty_course_description";
        public Guid CourseId { get; }
        
        public EmptyCourseDescriptionException(Guid courseId) 
            : base($"Empty description defined for course with ID: '{courseId}'.")
                => CourseId = courseId;
    }
}
