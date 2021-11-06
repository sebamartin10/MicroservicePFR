using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using MicroservicePFR.Domain.DTOs;
using System.Threading.Tasks;

public class FavouriteService : IFavouriteService
{
    private IFavouriteRepository favouriteRepository;
    private readonly IHttpClientFactory httpClientFactory;

    public FavouriteService(IFavouriteRepository repo,IHttpClientFactory httpClientFactory){
        this.httpClientFactory = httpClientFactory;
        favouriteRepository = repo;
        
    }

    public async Task<List<Favourite>> GetAllFavouritesFromUser(string userId)
    {
        var httpClient = httpClientFactory.CreateClient("Catalog");
        var result = await httpClient.GetAsync("/v1/articles/61845b4db9d8210009424228");
        if (result.IsSuccessStatusCode)
        {
            string responseBody = await result.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<ArticleDTO>(responseBody);
            var article = result.Content.ReadFromJsonAsync<ArticleDTO>();
        }
        List<Favourite> favourites = favouriteRepository.GetAllUserFavorites(userId);
        foreach (var favourite in favourites) {
            
        }
        return favouriteRepository.GetAllUserFavorites(userId);
    }

    public Favourite GetFavourite(string id)
    {
        return favouriteRepository.GetById(id);
    }

    public bool IsAlreadyAdded(Favourite favourite)
    {
        if(favouriteRepository.IsAlreadyAdded(favourite))
            return true;
        return false;
    }

    public void Remove(Favourite favourite)
    {
        favouriteRepository.Remove(favourite);
    }

    public void Store(Favourite favourite)
    {
        favouriteRepository.Store(favourite);
    }
    

}