using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;

public class FavouriteService : IFavouriteService
{
    private IFavouriteRepository favouriteRepository;
    public FavouriteService(IFavouriteRepository repo){
        favouriteRepository = repo;
    }
    public bool IsAlreadyAdded(Favourite favourite)
    {
        if(favouriteRepository.IsAlreadyAdded(favourite))
            return true;
        return false;
    }


    public void Store(Favourite favourite)
    {
        favouriteRepository.Store(favourite);
    }

}