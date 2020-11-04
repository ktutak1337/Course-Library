using System;
using System.Collections.Generic;

namespace CourseLibrary.Application.Commands.WriteModels
{
    public class ModuleWriteModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<VideoWriteModel> Videos { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
