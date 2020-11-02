using System;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Exceptions.Video;

namespace CourseLibrary.Core.Entities
{
    public class Video : IEntity<VideoId>
    {
        public VideoId Id { get; private set; }
        public string Name { get; private set; }
        public string VideoUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Video(VideoId id, string name, string videoUrl, string thumbnailUrl, DateTime createdAt)
        {
            Id = id;

            if (name.IsEmpty())
            {
                throw new EmptyVideoNameException(id);
            }

            Name = name;

            if (videoUrl.IsEmpty())
            {
                throw new EmptyVideoUrlException(id);
            }

            VideoUrl = videoUrl;

            if (thumbnailUrl.IsEmpty())
            {
                throw new EmptyVideoThumbnailUrlException(id);
            }

            ThumbnailUrl = thumbnailUrl;
            CreatedAt = createdAt;
        }
    }
}
