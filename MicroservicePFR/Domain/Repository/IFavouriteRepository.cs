using MicroservicePFR.Domain.Models;

namespace MicroservicePFR.Domain.Repository
{
    public interface IFavouriteRepository
    {
        public void Store(Favourite favourite);
    }
}
