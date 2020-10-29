using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Aggregates
{
    public class Student : AggregateRoot
    {
        public StudentId Id { get; private set; }
        public UserId UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
