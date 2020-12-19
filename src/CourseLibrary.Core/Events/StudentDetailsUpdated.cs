using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class StudentDetailsUpdated : IDomainEvent
    {
        public Student Student { get; }

        public StudentDetailsUpdated(Student student) 
            => Student = student;
    }
}
