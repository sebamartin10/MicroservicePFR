using MicroservicePFR.Application;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestCategoryController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
       
        IInterestCategoryService interestCategoryService;
        IAuthService authService;
        public InterestCategoryController(SqlServerDBContext dbContext, IInterestCategoryService interestCategoryService, IAuthService authService) {
            this.dbContext= dbContext; 
        
            this.interestCategoryService = interestCategoryService;
            this.authService = authService;

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(InterestCategory interestCategory)
        {
            var requestHeader = Request.Headers.TryGetValue("Authorization", out var token);
            Auth.bearerToken = token;
            if (!authService.IsAuthorized())
            {
                return Unauthorized();
            }
           
            AddInterestCategory action = new AddInterestCategory(interestCategoryService,authService);
            await action.AddCategory(interestCategory);

            return Ok();
        }
    }
}
