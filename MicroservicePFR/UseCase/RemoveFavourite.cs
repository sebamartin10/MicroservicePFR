using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Models.Exceptions;
using MicroservicePFR.Domain.RepositoryContracts;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MicroservicePFR.UseCase
{
    public class RemoveFavourite
    {
        IFavouriteService favouriteService;
        IFavouriteRepository favouriteRepository;
        FavouriteResponse favouriteResponse = new FavouriteResponse();    
        public RemoveFavourite(IFavouriteRepository repo,IFavouriteService service) {
            favouriteRepository = repo;
            favouriteService = service;
        }
        public async Task Remove(string articleID)
        {
            Favourite favourite = favouriteService.GetFavourite(articleID);
            if (favourite != null)
            {
                await favouriteService.Remove(favourite);
            
                
            }
            else {
                
                throw new NotFoundException("Favourite not found");
            }
        }
    }
}
