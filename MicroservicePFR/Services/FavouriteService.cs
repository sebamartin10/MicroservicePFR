using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.RepositoryContracts;
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
    private static HttpClient httpClient;
    public FavouriteService(IFavouriteRepository repo,IHttpClientFactory httpClientFactory){
        this.httpClientFactory = httpClientFactory;
        httpClient = httpClientFactory.CreateClient("Catalog");
        favouriteRepository = repo;
       
    }

    public async Task<List<FavouriteDTO>> GetAllFavouritesFromUser(string userId)
    {
        List<Favourite> favourites = favouriteRepository.GetAllUserFavorites(userId);
        List<FavouriteDTO> favouritesDTO = new List<FavouriteDTO>();
        foreach (var favourite in favourites)
        {
            var result = await httpClient.GetAsync("/v1/articles/"+favourite.articleID);
            if (result.IsSuccessStatusCode)
            {
                string responseBody = await result.Content.ReadAsStringAsync();
                var article = JsonConvert.DeserializeObject<ArticleDTO>(responseBody);
                favouritesDTO.Add(new FavouriteDTO
                {
                    articleId= article._id,
                    articleName = article.name,
                    articleDescription = article.description,
                    articleImage = article.image,
                    articlePrice = article.price.ToString(),
                });
            }
        }




        return favouritesDTO;
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

    public async Task Remove(Favourite favourite)
    {
        await favouriteRepository.Remove(favourite);
    }

    public async Task Store(Favourite favourite)
    {
        await favouriteRepository.Store(favourite);
    }
    

}