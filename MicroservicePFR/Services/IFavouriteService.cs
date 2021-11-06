using MicroservicePFR.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFavouriteService{
    bool IsAlreadyAdded(Favourite favourite);
    void Store(Favourite favourite);
    Favourite GetFavourite(string id);
    void Remove(Favourite favourite);
    Task<List<Favourite>> GetAllFavouritesFromUser(string userId);
}