using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicePFR.Infraestructure.Repository
{
    public class SqlServerFavouriteRepository : IFavouriteRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public SqlServerFavouriteRepository(SqlServerDBContext dbContext) {
            this._dbContext = dbContext;
        }
        public async Task Store(Favourite favourite)
        {
            
                _dbContext.Favourite.Add(favourite);
                await _dbContext.SaveChangesAsync();
            
        }
        public bool IsAlreadyAdded(Favourite favourite){
            
                var fav = _dbContext.Favourite.Find(favourite.articleID);
                if (fav != null)
                    return true;
                return false;
            
            
            
        }

        public async Task Remove(Favourite favourite)
        {
            _dbContext.Favourite.Remove(favourite);
            await _dbContext.SaveChangesAsync();
        }

        public Favourite GetById(string id)
        {
            return _dbContext.Favourite.Find(id);
        }

        public List<Favourite> GetAllUserFavorites(string userId)
        {
            List<Favourite> favourites = (from favourite in _dbContext.Favourite
                                         where favourite.userID==userId
                                         select favourite).ToList();
            return favourites;
        }
    }
}
