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
        IAuthService authService;
        public UserProfileController(SqlServerDBContext dbContext,IUserProfileRepository repo, IUserProfileService service,IAuthService authService) {
            this.dbContext = dbContext;
            this.userProfileRepository = repo;
            this.userProfileService = service;
            this.authService = authService; 
        }

        [HttpPost]
        public ActionResult Update(UserProfile user) {
            var requestHeader = Request.Headers.TryGetValue("Authorization", out var token);
            Auth.bearerToken = token;
            if (!authService.IsAuthorized())
            {
                return Unauthorized();
            }

           
            UpdateUser updateUser = new UpdateUser(userProfileRepository,userProfileService);
            updateUser.Update(user);
            return Ok();
        }
        
    }
}
