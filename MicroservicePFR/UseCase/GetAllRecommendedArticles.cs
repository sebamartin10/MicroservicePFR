using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Services;
using System.Collections.Generic;

namespace MicroservicePFR.UseCase
{
    public class GetAllRecommendedArticles
    {
        IRecommendedService service;
        IAuthService authService;
        public GetAllRecommendedArticles(IRecommendedService recommendedService,IAuthService authService) {
            this.service = recommendedService; 
            this.authService = authService;
        }
        public List<RecommendedDTO> GetAll() {
            User user = authService.GetCurrentUser();
            string category = service.GetHigherInterestCategory(user.id); 
            return service.GetAllRecommendedArticlesBy(category);
        }
    }
}
