using MicroservicePFR.Domain.Models;

public interface IFavouriteService{
    bool IsAlreadyAdded(Favourite favourite);
    void Store(Favourite favourite);
    Favourite GetFavourite(string id);
    void Remove(Favourite favourite);
}