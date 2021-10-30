using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;

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
            
                _dbContext.Favourite.Add(favourite);
                _dbContext.SaveChanges();
            
        }
        public bool IsAlreadyAdded(Favourite favourite){
            
                var fav = _dbContext.Favourite.Find(favourite.articleID);
                if (fav != null)
                    return true;
                return false;
            
            
            
        }
    }
}
