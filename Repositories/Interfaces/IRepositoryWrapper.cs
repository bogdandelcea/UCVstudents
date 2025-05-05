namespace UCVstudents.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IStudentRepository Student { get; }
         ITeacherRepository Teacher { get; }
        // Adaugă și altele ulterior (ex: ITeacherRepository, IUserRepository etc.)
        void Save();
    }
}
