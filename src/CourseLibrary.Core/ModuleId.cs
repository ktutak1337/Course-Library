using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class ModuleId : TypedIdValueBase
    {
        public ModuleId(Guid value) 
            : base(value) { }

        public static implicit operator ModuleId(Guid moduleId)
            => new ModuleId(moduleId);
    }
}
