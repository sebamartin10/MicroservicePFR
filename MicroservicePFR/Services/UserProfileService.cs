using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;

namespace MicroservicePFR.Services
{
    public class UserProfileService : IUserProfileService
    {
        private IUserProfileRepository userProfileRepository;
        public UserProfileService(IUserProfileRepository repo)
        {
            userProfileRepository = repo;
        }

        public void Create(UserProfile userProfile)
        {
            userProfileRepository.Create(userProfile);
        }

        public void Update(UserProfile userProfile)
        {
            userProfileRepository.Update(userProfile);
        }

        public bool UserProfileExists(string userID) {
            return userProfileRepository.UserProfileAlreadyExists(userID);
        }

  
    }
}
