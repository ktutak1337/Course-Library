using System;

namespace CourseLibrary.Application.Exceptions
{
    public class CourseNotFoundException : ApplicationException
    {
        public override string Code { get; } = "course_not_found";
        public Guid CourseId { get; }

        public CourseNotFoundException(Guid courseId) 
            : base($"Course with ID: '{courseId}' was not found.") 
                => CourseId = courseId;
    }
}
