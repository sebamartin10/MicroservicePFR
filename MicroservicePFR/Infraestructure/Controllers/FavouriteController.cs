using MicroservicePFR.Application;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouriteController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
        SqlServerFavouriteRepository favouriteRepository;
        FavouriteService favouriteService;

        public FavouriteController(SqlServerDBContext dbContext) {
            this.dbContext = dbContext;
            favouriteRepository = new SqlServerFavouriteRepository(dbContext);
            favouriteService = new FavouriteService(favouriteRepository);
        }   

        [HttpGet]
        public string Get()
        {
            return "Ok todo funcionando";
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
