using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroservicePFR.Services
{
    public class InterestCategoryService : IInterestCategoryService
    {
        IInterestCategoryRepository repository;
        private readonly IHttpClientFactory httpClientFactory;
        private static HttpClient httpClient;
        public InterestCategoryService(IInterestCategoryRepository repository, IHttpClientFactory httpClientFactory) {
            this.httpClientFactory = httpClientFactory;
            httpClient = httpClientFactory.CreateClient("Catalog");
            this.repository = repository;  

        }

        public async Task Create(InterestCategory interestCategory)
        {
            await repository.Create(interestCategory);
        }

        public async Task<InterestCategory> GetCategoryById(string interestCategoryId,string userId)
        {
            return await repository.FindCategoryById(interestCategoryId,userId);
        }

        public async Task Update(InterestCategory category)
        {
            await repository.Update(category);
        }
    }
}
