using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroservicePFR.Infraestructure.Repository
{
    public class SqlServerUserProfileRepository : IUserProfileRepository
    {
        private readonly SqlServerDBContext _dbContext;
        public SqlServerUserProfileRepository(SqlServerDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Create(UserProfile userProfile)
        {
            _dbContext.UserProfile.Add(userProfile);
            _dbContext.SaveChanges();
        }

        public void Update(UserProfile user)
        {
            //_dbContext.UserProfile.Update(user);
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }

        public bool UserProfileAlreadyExists(string userID)
        {
            var userProfile = (from x in _dbContext.UserProfile.AsNoTracking()
                               where x.userID == userID
                               select x).FirstOrDefault();
            if (userProfile != null)
                return true;
            return false;
        }
    }
}
