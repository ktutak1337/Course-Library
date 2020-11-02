using System;

namespace CourseLibrary.Core.Exceptions.Video
{
    public class EmptyVideoNameException : DomainException
    {
        public override string Code { get; } = "empty_video_name";
        public Guid VideoId { get; }
        
        public EmptyVideoNameException(Guid videoId) 
            : base($"Empty name defined for video with ID: '{videoId}'.")
                => VideoId = videoId;
    }
}
