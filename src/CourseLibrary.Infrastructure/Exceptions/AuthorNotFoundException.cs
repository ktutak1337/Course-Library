using System;

namespace CourseLibrary.Infrastructure.Exceptions
{
    public class AuthorNotFoundException : InfrastructureException
    {
        public override string Code { get; } = "author_not_found";
        public Guid AuthorId { get; }

        public AuthorNotFoundException(Guid authorId)
            : base($"Author with ID: '{authorId}' not found.") 
                => AuthorId = authorId;
    }
}
