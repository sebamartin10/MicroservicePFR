using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
using MicroservicePFR.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MicroservicePFR.UseCase
{
    public class AddFavourite
    {
        IFavouriteService favouriteService;
        IAuthService authService;
    
        FavouriteResponse response = new FavouriteResponse();
        public AddFavourite(IFavouriteService favouriteService,IAuthService authService) {
       
            this.favouriteService = favouriteService;
            this.authService = authService;
        }
        public async Task Add(string  articleID) {

            User user = authService.GetCurrentUser();
            Favourite favourite = new Favourite
            {
                userID = user.id,
                articleID= articleID    

            };
                if (!favouriteService.IsAlreadyAdded(favourite))
                {
                    await favouriteService.Store(favourite);

                }
   
              
        }
        
    }
}
