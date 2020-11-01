using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Entities
{
    public class Video : IEntity<VideoId>
    {
        public VideoId Id { get; private set; }
        public string Name { get; private set; }
        public string VideoUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }

        public Video(VideoId id, string name, string videoUrl, string thumbnailUrl)
        {
            Id = id;
            Name = name;
            VideoUrl = videoUrl;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}
