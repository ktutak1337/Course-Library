using System;

namespace CourseLibrary.Core.Exceptions.ParticipationInCourse
{
    public class EmptyProgressException : DomainException
    {
        public override string Code { get; } = "empty_course_description";
        public Guid ParticipationInCourseId { get; }
        
        public EmptyProgressException(Guid participationInCourseId) 
            : base($"Empty progress defined for participation in course with ID: '{participationInCourseId}'.")
                => ParticipationInCourseId = participationInCourseId;
    }
}
