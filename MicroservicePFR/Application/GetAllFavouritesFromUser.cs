using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System.Collections.Generic;

namespace MicroservicePFR.Application
{
    public class GetAllFavouritesFromUser
    {
        private IFavouriteRepository favouriteRepository;
        private IFavouriteService favouriteService;
        public GetAllFavouritesFromUser(IFavouriteRepository repo,IFavouriteService service) {
            favouriteRepository = repo;
            favouriteService = service;
        }
        public List<UserFavourite> GetFavourites(string userId) {
            List<Favourite> favourites = favouriteService.GetAllFavouritesFromUser(userId);
            List<UserFavourite> userFavourites = new List<UserFavourite>();
            foreach (var favourite in favourites) {
                userFavourites.Add(new UserFavourite
                {
                    articleId = favourite.articleID,
                    articleName= "Name of the article.",
                    articleDescription = "This is a description for this article.",
                    articleImage="Some image Id or Url",
                    articlePrice="$3500,00"
                });
            }
            return userFavourites;
        }
    }
}
