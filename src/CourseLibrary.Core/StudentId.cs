using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class StudentId : TypedIdValueBase
    {
        public StudentId(Guid value) 
            : base(value) { }

        public static implicit operator StudentId(Guid studentId)
            => new StudentId(studentId);
    }
}
