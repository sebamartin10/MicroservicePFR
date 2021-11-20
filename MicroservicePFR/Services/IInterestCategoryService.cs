using MicroservicePFR.Domain.Models;
using System.Threading.Tasks;

namespace MicroservicePFR.Services
{
    public interface IInterestCategoryService
    {   
         Task<InterestCategory> GetCategoryById(string interestCategoryId,string userId);
         Task Update(InterestCategory category);
         Task Create(InterestCategory interestCategory);
    }
}
