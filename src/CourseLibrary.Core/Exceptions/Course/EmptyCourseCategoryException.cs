using System;

namespace CourseLibrary.Core.Exceptions.Course
{
    public class EmptyCourseCategoryException : DomainException
    {
        public override string Code { get; } = "empty_course_category";
        public Guid CourseId { get; }
        
        public EmptyCourseCategoryException(Guid courseId) 
            : base($"Empty category defined for course with ID: '{courseId}'.")
                => CourseId = courseId;
    }
}
