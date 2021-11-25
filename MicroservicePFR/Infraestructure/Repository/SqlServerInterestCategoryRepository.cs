using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicePFR.Infraestructure.Repository
{
    public class SqlServerInterestCategoryRepository : IInterestCategoryRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public SqlServerInterestCategoryRepository(SqlServerDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Create(InterestCategory interestCategory)
        {
            _dbContext.InterestCategory.Add(interestCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InterestCategory> FindCategoryById(string interestCategoryId,string userId)
        {
            return  await (from x in _dbContext.InterestCategory.AsNoTracking()
                    where x.interestCategoryId==interestCategoryId && x.userId==userId
                    select x).FirstOrDefaultAsync(); 
        }

        

        public async Task Update(InterestCategory category)
        {
            _dbContext.Entry(category).State = EntityState.Detached;
            _dbContext.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
