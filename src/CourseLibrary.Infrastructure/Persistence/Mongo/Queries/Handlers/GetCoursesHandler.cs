using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Queries;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Queries.Handlers
{
    public class GetCoursesHandler : IQueryHandler<GetCourses, IEnumerable<CourseDto>>
    {
        private readonly IMongoRepository<CourseDocument, Guid> _repository;

        public GetCoursesHandler(IMongoRepository<CourseDocument, Guid> repository)
            => _repository = repository;

        public async Task<IEnumerable<CourseDto>> HandleAsync(GetCourses query)
            => (await _repository.FindAsync(_ => true))
                .Select(documnet => documnet.AsDto());
    }
}
