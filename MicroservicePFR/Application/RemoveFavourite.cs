using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Models.Exceptions;
using MicroservicePFR.Domain.Repository;
using System;
using System.Net;

namespace MicroservicePFR.Application
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
        public FavouriteResponse Remove(string articleID)
        {
            Favourite favourite = favouriteService.GetFavourite(articleID);
            if (favourite != null)
            {
                favouriteRepository.Remove(favourite);
                favouriteResponse.Message = "You have deleted an article from your favourite list.";
                favouriteResponse.code = (int)HttpStatusCode.OK;
                return favouriteResponse;
            }
            else {
                favouriteResponse.Message = "Favourite not found.";
                throw new NotFoundException("Favourite not found");
            }
        }
    }
}
