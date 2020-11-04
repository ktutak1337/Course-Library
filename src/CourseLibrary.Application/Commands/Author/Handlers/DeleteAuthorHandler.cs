using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Author.Handlers
{
    public class DeleteAuthorHandler : ICommandHandler<DeleteAuthor>
    {
        private readonly IAuthorsService _authorsService;

        public DeleteAuthorHandler(IAuthorsService authorsService) 
            => _authorsService = authorsService;

        public async Task HandleAsync(DeleteAuthor command)
            => await _authorsService.DeleteAsync(command.Id);
    }
}
