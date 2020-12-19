using System;
using System.Collections.Generic;
using CourseLibrary.Core.BuildingBlocks;
using CourseLibrary.Core.Entities;
using CourseLibrary.Core.Events;
using CourseLibrary.Core.Exceptions.Course;
using CourseLibrary.Core.ValueObjects;

namespace CourseLibrary.Core.Aggregates
{
    public class Course : AggregateRoot
    {
        private ISet<Module> _modules = new HashSet<Module>();
        private ISet<Author> _authors = new HashSet<Author>();

        public CourseId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<Module> Modules
        {
            get { return _modules; }
            private set { _modules = new HashSet<Module>(value); }
        }

        public IEnumerable<Author> Authors
        {
            get { return _authors; }
            private set { _authors = new HashSet<Author>(value); }
        }

        private Course() { }
        
        public Course(CourseId id, string name, string description, string category, DateTime createdAt,
            IEnumerable<Module> modules, IEnumerable<Author> authors)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            SetCategory(category);
            Modules = modules ?? throw new EmptyModulesException(id);
            Authors = authors ?? throw new EmptyAuthorsException(id);
            CreatedAt = createdAt;

            AddDomainEvent(new CourseCreated(this));
        }

        public void Update(Course course)
        {
            Name = course.Name;
            Description = course.Description;
            Category = course.Category;
            Modules = course.Modules;
            Authors = course.Authors;

            AddDomainEvent(new CourseUpdated(this));
        }

        private void SetName(string name)
        {
            if(name.IsEmpty())
            {
                throw new EmptyCourseNameException(Id);
            }

            Name = name;
        }

        private void SetDescription(string description)
        {
            if(description.IsEmpty())
            {
                throw new EmptyCourseDescriptionException(Id);
            }

            Description = description;
        }

        private void SetCategory(string category)
        {
            if(category.IsEmpty())
            {
                throw new EmptyCourseCategoryException(Id);
            }

            Category = category;
        }
    }
}
