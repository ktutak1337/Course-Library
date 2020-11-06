using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
    {
        private readonly ICategoriesService _categoriesService;

        public GetCategoriesHandler(ICategoriesService categoriesService) 
            => _categoriesService = categoriesService;

        public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
            => await _categoriesService.GetCategoriesAsync();
    }
}
