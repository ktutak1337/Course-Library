using System;

namespace CourseLibrary.Core.Exceptions.Module
{
    public class EmptyVideosException : DomainException
    {
        public override string Code { get; } = "empty_videos";
        public Guid ModuleId { get; }
        
        public EmptyVideosException(Guid moduleId) 
            : base($"An empty collection of videos defined for module with ID: '{moduleId}'.")
                => ModuleId = moduleId;
    }
}
