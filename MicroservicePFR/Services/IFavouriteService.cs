using MicroservicePFR.Domain.Models;
using System.Collections.Generic;

public interface IFavouriteService{
    bool IsAlreadyAdded(Favourite favourite);
    void Store(Favourite favourite);
    Favourite GetFavourite(string id);
    void Remove(Favourite favourite);
    List<Favourite> GetAllFavouritesFromUser(string userId);
}