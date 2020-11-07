using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Category.Handlers
{
    public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
    {
        private readonly ICategoriesService _categoriesService;

        public UpdateCategoryHandler(ICategoriesService categoriesService) 
            => _categoriesService = categoriesService;

        public async Task HandleAsync(UpdateCategory command)
            => await _categoriesService.UpdateAsync(command);
    }
}
