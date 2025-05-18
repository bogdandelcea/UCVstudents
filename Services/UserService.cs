using Microsoft.AspNetCore.Identity;
using UCVstudents.Repositories.Interfaces;
using UCVstudents.Services.Interfaces;
//update

namespace UCVstudents.Services
{
    public class UserService: IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateUser(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            _repositoryWrapper.UserRepository.Create(user);
            _repositoryWrapper.Save();
        }

        public void DeleteUser(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            if (string.IsNullOrEmpty(user.Id))
            {
                throw new ArgumentException("Invalid UserId.", nameof(user.Id));
            }

            _repositoryWrapper.UserRepository.Delete(user);
            _repositoryWrapper.Save();
        }

        public void UpdateUser(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            if (string.IsNullOrEmpty(user.Id))
            {
                throw new ArgumentException("Invalid UserId.", nameof(user.Id));
            }

            _repositoryWrapper.UserRepository.Update(user);
            _repositoryWrapper.Save();
        }

        public IdentityUser GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Invalid UserId.", nameof(id));
            }

            try
            {
                var user = _repositoryWrapper.UserRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User not found.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving the user by ID.", ex);
            }
        } 

        public List<IdentityUser> GetUsers()
        {
            try
            {
                return _repositoryWrapper.UserRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving users.", ex);
            }
        }

    }
}
