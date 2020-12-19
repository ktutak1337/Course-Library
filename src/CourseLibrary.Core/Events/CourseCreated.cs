using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class CourseCreated : IDomainEvent
    {
        public Course Course { get; }

        public CourseCreated(Course course) 
            => Course = course;
    }
}
