using System;

namespace CourseLibrary.Infrastructure.Exceptions
{
    public class CategoryNotFoundException : InfrastructureException
    {
        public override string Code { get; } = "category_not_found";
        public Guid CategoryId { get; }

        public CategoryNotFoundException(Guid categoryId)
            : base($"Category with ID: '{categoryId}' not found.") 
                => CategoryId = categoryId;
    }
}
