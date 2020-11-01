using System;
using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core
{
    public class VideoId : TypedIdValueBase
    {
        public VideoId(Guid value) 
            : base(value) { }

        public static implicit operator VideoId(Guid videoId)
            => new VideoId(videoId);
    }
}
