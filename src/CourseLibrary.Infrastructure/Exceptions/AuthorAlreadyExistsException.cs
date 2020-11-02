using System;

namespace CourseLibrary.Infrastructure.Exceptions
{
    public class AuthorAlreadyExistsException : InfrastructureException
    {
        public override string Code { get; } = "author_already_exists";
        public Guid AuthorId { get; }

        public AuthorAlreadyExistsException(Guid authorId)
            : base($"Author with ID: '{authorId}' already exists.") 
                => AuthorId = authorId;
    }
}
