using MicroservicePFR.Application;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicePFR.Infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouriteController : ControllerBase
    {
        private readonly SqlServerDBContext dbContext;
        SqlServerFavouriteRepository favouriteRepository;

        public FavouriteController(SqlServerDBContext dbContext) {
            this.dbContext = dbContext;
            favouriteRepository = new SqlServerFavouriteRepository(dbContext);
        }   

        [HttpGet]
        public string Get()
        {
            return "Ok todo funcionando";
        }
        [HttpPost]
        public void Post(Favourite favourite) {
            AddFavourite favouriteAction = new AddFavourite(favouriteRepository);
            favouriteAction.Add(favourite);

            

        }
    }
}
