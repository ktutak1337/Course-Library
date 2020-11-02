using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetAuthorHandler : IQueryHandler<GetAuthor, AuthorDto>
    {
        private readonly IAuthorsService _authorsService;

        public GetAuthorHandler(IAuthorsService authorsService) 
            => _authorsService = authorsService;

        public async Task<AuthorDto> HandleAsync(GetAuthor query) 
            => await _authorsService.GetAsync(query.Id);
    }
}
