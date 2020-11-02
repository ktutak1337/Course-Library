using System;

namespace CourseLibrary.Core.Exceptions.Video
{
    public class EmptyVideoUrlException : DomainException
    {
        public override string Code { get; } = "empty_video_url";
        public Guid VideoId { get; }
        
        public EmptyVideoUrlException(Guid videoId) 
            : base($"Empty video URL address defined for video with ID: '{videoId}'.")
                => VideoId = videoId;
    }
}
