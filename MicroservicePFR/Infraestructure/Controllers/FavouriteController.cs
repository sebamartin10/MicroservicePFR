
using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
using MicroservicePFR.Services;
using MicroservicePFR.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
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
        IAuthService authService;
        public FavouriteController(SqlServerDBContext dbContext,IFavouriteService service,IFavouriteRepository repository,IAuthService authService) {
            this.dbContext = dbContext;
            this.favouriteRepository = repository;
            this.favouriteService = service;
            this.authService = authService;
        }   

        [HttpGet]
        public async Task<List<FavouriteDTO>> Get()
        {
            string userId = "614d0947d2139c881964244f";
            GetAllFavouritesFromUser action = new GetAllFavouritesFromUser(favouriteService);
            return await action.GetFavourites(userId); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Favourite favourite) {
            var requestHeader = Request.Headers.TryGetValue("Authorization", out var token);
            Auth.bearerToken = token;
            if (!authService.IsAuthorized()) {
                return Unauthorized();
            }
            AddFavourite action = new AddFavourite(favouriteService,authService);
            
            await action.Add(favourite.articleID);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string articleId) {
            var requestHeader = Request.Headers.TryGetValue("Authorization", out var token);
            Auth.bearerToken = token;
            if (!authService.IsAuthorized())
            {
                return Unauthorized();
            }
            RemoveFavourite favouriteAction = new RemoveFavourite(favouriteRepository, favouriteService);
                await favouriteAction.Remove(articleId);
                return Ok();
            
            
            
        }

 
    }
}
