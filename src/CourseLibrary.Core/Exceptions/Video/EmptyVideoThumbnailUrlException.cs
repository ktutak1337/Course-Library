using System;

namespace CourseLibrary.Core.Exceptions.Video
{
    public class EmptyVideoThumbnailUrlException : DomainException
    {
        public override string Code { get; } = "empty_video_thumbnail_url";
        public Guid VideoId { get; }
        
        public EmptyVideoThumbnailUrlException(Guid videoId) 
            : base($"Empty thumbnail URL address defined for video with ID: '{videoId}'.")
                => VideoId = videoId;
    }
}
