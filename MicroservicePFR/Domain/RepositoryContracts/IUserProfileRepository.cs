using MicroservicePFR.Domain.Models;

namespace MicroservicePFR.Domain.RepositoryContracts
{
    public interface IUserProfileRepository
    {
        void Update(UserProfile user);
        bool UserProfileAlreadyExists(string userID);
        void Create(UserProfile userProfile);
    }
}
