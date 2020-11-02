using System;

namespace CourseLibrary.Core.Exceptions.Module
{
    public class EmptyModuleNameException : DomainException
    {
        public override string Code { get; } = "empty_module_name";
        public Guid ModuleId { get; }
        
        public EmptyModuleNameException(Guid moduleId) 
            : base($"Empty name defined for module with ID: '{moduleId}'.")
                => ModuleId = moduleId;
    }
}
