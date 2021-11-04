using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Services;

namespace MicroservicePFR.Application
{
    public class UpdateUser
    {
        private IUserProfileRepository userProfileRepository;
        private IUserProfileService userService;
        public UpdateUser(IUserProfileRepository repo, IUserProfileService service) {
            this.userProfileRepository = repo;
            this.userService = service;
        }
        public void Update(UserProfile user) {
            if (userService.UserProfileExists(user.userID))
            {
                userService.Update(user);
            }
            else {
                userService.Create(user);
            }
        }
    }
}
