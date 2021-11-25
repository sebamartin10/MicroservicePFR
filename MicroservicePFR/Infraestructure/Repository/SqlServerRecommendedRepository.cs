using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
using System.Collections.Generic;
using System.Linq;

namespace MicroservicePFR.Infraestructure.Repository
{
    public class SqlServerRecommendedRepository : IRecommendedRepository
    {
        private readonly SqlServerDBContext dbContext;
        public SqlServerRecommendedRepository(SqlServerDBContext dbContext) {
            this.dbContext = dbContext; 
        }
        public List<InterestCategory> GetInterestCategoriesBy(string userId)
        {
            return (from x in dbContext.InterestCategory
                    where x.userId == userId
                    select x).ToList();
                    
        }
    }
}
