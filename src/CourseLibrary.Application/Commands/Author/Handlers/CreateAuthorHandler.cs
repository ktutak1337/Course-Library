using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Author.Handlers
{
    public class CreateAuthorHandler : ICommandHandler<CreateAuthor>
    {
        private readonly IAuthorsService _authorsService;

        public CreateAuthorHandler(IAuthorsService authorsService) 
            => _authorsService = authorsService;

        public async Task HandleAsync(CreateAuthor command) 
            => await _authorsService.CreateAsync(command);
    }
}
