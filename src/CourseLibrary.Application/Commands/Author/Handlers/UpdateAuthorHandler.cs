using System.Threading.Tasks;
using Convey.CQRS.Commands;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Application.Commands.Author.Handlers
{
    public class UpdateAuthorHandler : ICommandHandler<UpdateAuthor>
    {
        private readonly IAuthorsService _authorsService;

        public UpdateAuthorHandler(IAuthorsService authorsService) 
            => _authorsService = authorsService;

        public async Task HandleAsync(UpdateAuthor command) 
            => await _authorsService.UpdateAsync(command);
    }
}
