using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using CourseLibrary.Application.Commands.Category;
using CourseLibrary.Application.DTOs;
using CourseLibrary.Application.Services;
using CourseLibrary.Infrastructure.Exceptions;
using CourseLibrary.Infrastructure.Mappings;
using CourseLibrary.Infrastructure.Persistence.Mongo.Documents;

namespace CourseLibrary.Infrastructure.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IMongoRepository<CategoryDocument, Guid> _repository;

        public CategoriesService(IMongoRepository<CategoryDocument, Guid> repository) 
            => _repository = repository;

        public async Task<CategoryDto> GetAsync(Guid id)
            => (await _repository.GetAsync(id))
                ?.AsDto();

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
            => (await _repository.FindAsync(_ => true))
                ?.Select(order => order.AsDto());
        
        public async Task CreateAsync(CreateCategory command)
        {
            if(await _repository.ExistsAsync(document => document.Id == command.Id))
            {
                throw new CategoryAlreadyExistsException(command.Id);
            }

            var category = new CategoryDto
            {
                Id = command.Id, 
                Name = command.Name,
                Description = command.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(category.AsDocument());
        }

        public async Task UpdateAsync(UpdateCategory command)
        {
            var category = await _repository.GetAsync(command.Id);
            
            if(category is null)
            {
                throw new AuthorNotFoundException(command.Id);
            }

            category.Name = command.Name;
            category.Description = command.Description;

            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}