using System;

namespace CourseLibrary.Core.Exceptions.Module
{
    public class EmptyModuleDescriptionException : DomainException
    {
        public override string Code { get; } = "empty_module_description";
        public Guid ModuleId { get; }
        
        public EmptyModuleDescriptionException(Guid moduleId) 
            : base($"Empty description defined for module with ID: '{moduleId}'.")
                => ModuleId = moduleId;
    }
}
