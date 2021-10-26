using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;

namespace MicroservicePFR.Application
{
    public class AddFavourite
    {
        IFavouriteRepository favouriteRepository;
        public AddFavourite(IFavouriteRepository repository) {
            this.favouriteRepository = repository;
        }
        public void Add(Favourite favourite) {
            favourite.userID = "1";
            favourite.articleID = "100";

            favouriteRepository.Store(favourite);
        }
    }
}
