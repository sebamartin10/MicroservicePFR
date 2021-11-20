using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicePFR.Application
{
    public class GetAllFavouritesFromUser
    {
       
        private IFavouriteService favouriteService;
        public GetAllFavouritesFromUser(IFavouriteService service) {
          
            favouriteService = service;
        }
        public async Task<List<FavouriteDTO>> GetFavourites(string userId) {
            return await favouriteService.GetAllFavouritesFromUser(userId);
            
        }
    }
}
