namespace UCVstudents.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IStudentRepository Student { get; }
        ITeacherRepository TeacherRepository { get; }
        // Adaugă și altele ulterior (ex: ITeacherRepository, IUserRepository etc.)
        void Save();
    }
}
