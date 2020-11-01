using System.Collections.Generic;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;

namespace CourseLibrary.Core.Aggregates
{
    public class Course : AggregateRoot
    {
        private ISet<Video> _videos = new HashSet<Video>();

        public CourseId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Video> Videos
        {
            get { return _videos; }
            private set { _videos = new HashSet<Video>(value); }
        }
    }
}
