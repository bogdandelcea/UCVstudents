namespace UCVstudents.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        // Adaugă și altele ulterior (ex: ITeacherRepository, IUserRepository etc.)
        ISubjectRepository Subject { get; }
        IGradeRepository Grade {get; }
        IDocumentRepository Document { get; }


        void Save();
    }
}
