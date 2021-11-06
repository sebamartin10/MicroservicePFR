using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<FavouriteDTO>> GetFavourites(string userId) {
            List<Favourite> favourites = await favouriteService.GetAllFavouritesFromUser(userId);
            List<FavouriteDTO> userFavourites = new List<FavouriteDTO>();
            foreach (var favourite in favourites) {
                userFavourites.Add(new FavouriteDTO
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
