using MicroservicePFR.Domain.Models;

namespace MicroservicePFR.Services
{
    public interface IUserProfileService
    {
        bool UserProfileExists(string userID);
        void Create(UserProfile userProfile);
        void Update(UserProfile userProfile);
    }
}
