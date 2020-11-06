using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Category.Handlers
{
    public class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
    {
        private readonly ICategoriesService _categoriesService;

        public DeleteCategoryHandler(ICategoriesService categoriesService) 
            => _categoriesService = categoriesService;

        public async Task HandleAsync(DeleteCategory command)
            => await _categoriesService.DeleteAsync(command.Id);
    }
}
