using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.ValueObjects
{
    public class Progress : ValueObject
    {
        public double Value { get; }

        public Progress(double value) 
            => Value = value;
    }
}
