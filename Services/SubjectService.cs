using System.Collections.Generic;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepositoryWrapper _repository;

        public SubjectService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Subject> GetAll() => _repository.Subject.GetAll();
        public Subject GetById(int id) => _repository.Subject.GetById(id);
        public void Create(Subject subject)
        {
            _repository.Subject.Create(subject);
            _repository.Subject.Save();
        }

        public void Update(Subject subject)
        {
            _repository.Subject.Update(subject);
            _repository.Subject.Save();
        }

        public void Delete(int id)
        {
            var subject = _repository.Subject.GetById(id);
            if (subject != null)
            {
                _repository.Subject.Delete(subject);
                _repository.Subject.Save();
            }
        }
    }
}
