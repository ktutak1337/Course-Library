using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Core.Aggregates;
using CourseLibrary.Core.Repositories;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Persistence.Mongo.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly IMongoRepository<CourseDocument, Guid> _repository;

        public CoursesRepository(IMongoRepository<CourseDocument, Guid> repository) 
            => _repository = repository;

        public async Task<Course> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                ?.AsEntity();

        public async Task<IEnumerable<Course>> BrowseAsync()
            => (await _repository.FindAsync(_ => true))
                ?.Select(documnet => documnet.AsEntity());

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(document => document.Id == id);

        public async Task AddAsync(Course course)
            => await _repository.AddAsync(course.AsDocument());

        public async Task UpdateAsync(Course course)
            => await _repository.UpdateAsync(course.AsDocument());

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
