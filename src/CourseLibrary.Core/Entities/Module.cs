using System;
using System.Collections.Generic;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.Module;

namespace CourseLibrary.Core.Entities
{
    public class Module : IEntity<ModuleId>
    {
        private ISet<Video> _videos = new HashSet<Video>();

        public ModuleId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public IEnumerable<Video> Videos
        {
            get { return _videos; }
            private set { _videos = new HashSet<Video>(value); }
        }

        private Module() { }

        public Module(ModuleId id, string name, string description, IEnumerable<Video> videos, DateTime? createdAt = null)
        {
            Id = id;

            if (name.IsEmpty())
            {
                throw new EmptyModuleNameException(id);
            }

            Name = name;

            if (description.IsEmpty())
            {
                throw new EmptyModuleDescriptionException(id);
            }

            Description = description;
            Videos = videos ?? throw new EmptyVideosException(id);
            CreatedAt = createdAt ?? DateTime.UtcNow;
        }
    }
}
