using Microsoft.AspNetCore.Identity;
using UCVstudents.Data;
using UCVstudents.Repositories.Interfaces;

namespace UCVstudents.Repositories
{
    public class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
