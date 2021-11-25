using MicroservicePFR.Domain.Models;
using System;
using System.Collections.Generic;

namespace MicroservicePFR.Domain.RepositoryContracts
{
    public interface IRecommendedRepository
    {
        List<InterestCategory> GetInterestCategoriesBy(string userId);
        
    }
}
