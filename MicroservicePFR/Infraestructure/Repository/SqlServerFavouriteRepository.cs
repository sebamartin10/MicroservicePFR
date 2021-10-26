using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;

namespace MicroservicePFR.Infraestructure.Repository
{
    public class SqlServerFavouriteRepository : IFavouriteRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public SqlServerFavouriteRepository(SqlServerDBContext dbContext) {
            this._dbContext = dbContext;
        }
        public void Store(Favourite favourite)
        {
            _dbContext.Add(favourite);
            _dbContext.SaveChanges();

        }
    }
}
