using MicroservicePFR.Application;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Infraestructure.Repository;
using MicroservicePFR.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
        IUserProfileRepository userProfileRepository;
        IUserProfileService userProfileService;
        public UserProfileController(SqlServerDBContext dbContext,IUserProfileRepository repo, IUserProfileService service) {
            this.dbContext = dbContext;
            this.userProfileRepository = repo;
            this.userProfileService = service;
        }

        [HttpPost]
        public void Update(UserProfile user) {
            UpdateUser updateUser = new UpdateUser(userProfileRepository,userProfileService);
            updateUser.Update(user);
        }
        
    }
}
