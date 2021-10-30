using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;

public class FavouriteService : IFavouriteService
{
    private IFavouriteRepository favouriteRepository;
    public FavouriteService(IFavouriteRepository repo){
        favouriteRepository = repo;
    }

    public Favourite GetFavourite(string id)
    {
        return favouriteRepository.GetById(id);
    }

    public bool IsAlreadyAdded(Favourite favourite)
    {
        if(favouriteRepository.IsAlreadyAdded(favourite))
            return true;
        return false;
    }

    public void Remove(Favourite favourite)
    {
        favouriteRepository.Remove(favourite);
    }

    public void Store(Favourite favourite)
    {
        favouriteRepository.Store(favourite);
    }
    

}