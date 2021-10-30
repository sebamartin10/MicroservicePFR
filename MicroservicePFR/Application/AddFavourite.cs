using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;
using System.Net;

namespace MicroservicePFR.Application
{
    public class AddFavourite
    {
        IFavouriteService favouriteService;
        IFavouriteRepository favouriteRepository;
        FavouriteResponse response = new FavouriteResponse();
        public AddFavourite(IFavouriteRepository repository,IFavouriteService favouriteService) {
            this.favouriteRepository = repository;
            this.favouriteService = favouriteService;
        }
        public FavouriteResponse Add(Favourite favourite) {
            
                favourite.userID = "2";
                favourite.articleID = "101";
                if (!favouriteService.IsAlreadyAdded(favourite))
                {
                    favouriteRepository.Store(favourite);

                response.Message = "You have added an article to you favourite list.";
                response.code = (int)HttpStatusCode.OK;
                return response;
                }
            response.Message = "You have already added this article to your favourite list.";
            response.code = (int)HttpStatusCode.Conflict;
            return response;
              
        }
    }
}
