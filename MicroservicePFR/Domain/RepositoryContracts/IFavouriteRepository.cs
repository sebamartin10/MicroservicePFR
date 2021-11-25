using MicroservicePFR.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicePFR.Domain.RepositoryContracts
{
    public interface IFavouriteRepository
    {
        public Task Store(Favourite favourite);
        public bool IsAlreadyAdded(Favourite favourite);
        public Task Remove(Favourite favourite);
        public Favourite GetById(string id);
        public List<Favourite> GetAllUserFavorites(string userId);
    }
}
