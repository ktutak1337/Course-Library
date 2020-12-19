using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Events
{
    public class StudentCreated : IDomainEvent
    {
        public Student Student { get; }

        public StudentCreated(Student student) 
            => Student = student;
    }
}
