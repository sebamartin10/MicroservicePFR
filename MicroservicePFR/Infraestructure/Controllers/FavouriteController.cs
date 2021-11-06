using MicroservicePFR.Application;
using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouriteController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
        IFavouriteRepository favouriteRepository;
        IFavouriteService favouriteService;

        public FavouriteController(SqlServerDBContext dbContext,IFavouriteService service,IFavouriteRepository repository) {
            this.dbContext = dbContext;
            this.favouriteRepository = repository;
            this.favouriteService = service;
        }   

        [HttpGet]
        public async Task<List<FavouriteDTO>> Get()
        {
            string userId = "1";
            GetAllFavouritesFromUser getFavouritesAction = new GetAllFavouritesFromUser(favouriteRepository,favouriteService);
            return await getFavouritesAction.GetFavourites(userId); 
        }
        [HttpPost]
        public FavouriteResponse Post(Favourite favourite) {
            AddFavourite favouriteAction = new AddFavourite(favouriteRepository,favouriteService);
            return favouriteAction.Add(favourite);            

        }
        [HttpDelete]
        public FavouriteResponse Delete(string articleId) {
            
                RemoveFavourite favouriteAction = new RemoveFavourite(favouriteRepository, favouriteService);
                return favouriteAction.Remove(articleId);
            
            
            
        }
    }
}
