using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Category.Handlers
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly ICategoriesService _categoriesService;

        public CreateCategoryHandler(ICategoriesService categoriesService) 
            => _categoriesService = categoriesService;

        public async Task HandleAsync(CreateCategory command)
            => await _categoriesService.CreateAsync(command);
    }
}
