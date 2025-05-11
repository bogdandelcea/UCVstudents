using System.Collections.Generic;
using UCVstudents.Models;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;

namespace UCVstudents.Services
{
    public class GradeService : IGradeService
    {
        private readonly IRepositoryWrapper _repository;

        public GradeService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Grade> GetAll() => _repository.Grade.GetAll();
        public Grade GetById(int id) => _repository.Grade.GetById(id);
        public void Create(Grade grade)
        {
            _repository.Grade.Create(grade);
            _repository.Grade.Save();
        }

        public void Update(Grade grade)
        {
            _repository.Grade.Update(grade);
            _repository.Grade.Save();
        }

        public void Delete(int id)
        {
            var grade = _repository.Grade.GetById(id);
            if (grade != null)
            {
                _repository.Grade.Delete(grade);
                _repository.Grade.Save();
            }
        }
    }
}
