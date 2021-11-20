using MicroservicePFR.Domain.DTOs;
using System.Collections.Generic;

namespace MicroservicePFR.Services
{
    public interface IRecommendedService
    {
        string GetHigherInterestCategory(string userId);
        List<RecommendedDTO> GetAllRecommendedArticlesBy(string category);
    }
}
