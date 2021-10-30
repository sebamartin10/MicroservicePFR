using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Remove(Favourite favourite)
        {
            _dbContext.Favourite.Remove(favourite);
            _dbContext.SaveChanges();
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
