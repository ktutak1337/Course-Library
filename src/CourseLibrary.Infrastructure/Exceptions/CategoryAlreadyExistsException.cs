using System;

namespace CourseLibrary.Infrastructure.Exceptions
{
    public class CategoryAlreadyExistsException : InfrastructureException
    {
        public override string Code { get; } = "category_already_exists";
        public Guid CategoryId { get; }

        public CategoryAlreadyExistsException(Guid categoryId)
            : base($"Category with ID: '{categoryId}' already exists.") 
                => CategoryId = categoryId;
    }
}
