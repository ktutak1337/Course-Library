using System.Threading.Tasks;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto>
    {
        private readonly ICategoriesService _categoriesService;

        public GetCategoryHandler(ICategoriesService categoriesService) 
            => _categoriesService = categoriesService;

        public async Task<CategoryDto> HandleAsync(GetCategory query)
            => await _categoriesService.GetAsync(query.Id);
    }
}
