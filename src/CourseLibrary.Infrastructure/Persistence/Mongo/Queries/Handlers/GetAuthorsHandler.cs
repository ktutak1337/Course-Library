using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Application.Services;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetAuthorsHandler : IQueryHandler<GetAuthors, IEnumerable<AuthorDto>>
    {
        private readonly IAuthorsService _authorsService;

        public GetAuthorsHandler(IAuthorsService authorsService) 
            => _authorsService = authorsService;

        public async Task<IEnumerable<AuthorDto>> HandleAsync(GetAuthors query)
            => await _authorsService.GetAuthorsAsync();
    }
}
