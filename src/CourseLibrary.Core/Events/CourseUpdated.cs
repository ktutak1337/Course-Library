using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class CourseUpdated : IDomainEvent
    {
        public Course Course { get; }

        public CourseUpdated(Course course) 
            => Course = course;
    }
}
