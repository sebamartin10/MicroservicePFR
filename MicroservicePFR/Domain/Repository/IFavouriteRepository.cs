using MicroservicePFR.Domain.Models;

namespace MicroservicePFR.Domain.Repository
{
    public interface IFavouriteRepository
    {
        public void Store(Favourite favourite);
        public bool IsAlreadyAdded(Favourite favourite);
        public void Remove(Favourite favourite);
        public Favourite GetById(string id);
    }
}
