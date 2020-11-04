using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.ValueObjects
{
    public class Author : ValueObject
    {
        public string FullName { get; }
        public string ImageUrl { get; }
        public string Description { get; }

        public Author(string fullName, string imageUrl, string description)
        {
            FullName = fullName;
            ImageUrl = imageUrl;
            Description = description;
        }
    }
}
