﻿using UCVstudents.Data;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _context;
        private IStudentRepository _student;
        private ITeacherRepository? _teacherRepository;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IStudentRepository Student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_context);
                }
                return _student;
            }
        }
        
      public ITeacherRepository Teacher
      {
        get
        {
         if (_teacherRepository == null)
        {
            _teacherRepository = new TeacherRepository(_context);
        }
        return _teacherRepository;
       }
     }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
