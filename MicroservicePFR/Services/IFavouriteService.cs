using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFavouriteService{
    bool IsAlreadyAdded(Favourite favourite);
    Task Store(Favourite favourite);
    Favourite GetFavourite(string id);
    Task Remove(Favourite favourite);
    Task<List<FavouriteDTO>> GetAllFavouritesFromUser(string userId);
}