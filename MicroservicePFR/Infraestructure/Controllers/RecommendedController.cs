using MicroservicePFR.Application;
using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendedController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
        private IRecommendedService service;
       
        IAuthService authService;
        public RecommendedController(IAuthService authService,IRecommendedService service) {
            this.authService= authService;  
            this.service = service;
        }
        [HttpGet]
        public List<RecommendedDTO> GetRecommendedArticles()
        {
            var requestHeader = Request.Headers.TryGetValue("Authorization", out var token);
            Auth.bearerToken = token;
            if (!authService.IsAuthorized())
            {
                return new List<RecommendedDTO>();
            }
            GetAllRecommendedArticles action = new GetAllRecommendedArticles(service,authService);
            return action.GetAll();


        }
    }
}
