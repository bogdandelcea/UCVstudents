using UCVstudents.Data;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _context;
        private IStudentRepository _student;
        private ITeacherRepository? _teacherRepository;
        private ISubjectRepository? _subjectRepository; 
        private IGradeRepository _grade;
        private IDocumentRepository _document;



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

        public ISubjectRepository Subject
        {
            get
            {
                if (_subjectRepository == null)
                {
                    _subjectRepository = new SubjectRepository(_context);
                }
                return _subjectRepository;
            }
        }
        public IGradeRepository Grade => _grade ??= new GradeRepository(_context);
        public IDocumentRepository Document => _document ??= new DocumentRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
