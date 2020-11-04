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
    public class StudentsRepository : IStudentsRepository
    {
        private readonly IMongoRepository<StudentDocument, Guid> _repository;

        public StudentsRepository(IMongoRepository<StudentDocument, Guid> repository) 
            => _repository = repository;

        public async Task<Student> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                ?.AsEntity();

        public async Task<IEnumerable<Student>> BrowseAsync()
            => (await _repository.FindAsync(_ => true))
                ?.Select(documnet => documnet.AsEntity());

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(document => document.UserId == id);

        public async Task AddAsync(Student student)
            => await _repository.AddAsync(student.AsDocument());

        public async Task UpdateAsync(Student student)
            => await _repository.UpdateAsync(student.AsDocument());

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
