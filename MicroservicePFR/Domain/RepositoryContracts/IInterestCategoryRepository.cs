using MicroservicePFR.Domain.Models;
using System.Threading.Tasks;

namespace MicroservicePFR.Domain.RepositoryContracts
{
    public interface IInterestCategoryRepository
    {
         Task Create(InterestCategory interestCategory);
         Task<InterestCategory> FindCategoryById(string interestCategoryId,string userId);
         Task Update(InterestCategory category);
    }
}
