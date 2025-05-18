using Microsoft.AspNetCore.Identity;

namespace UCVstudents.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
    }
}