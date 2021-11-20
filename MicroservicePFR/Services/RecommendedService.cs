using MicroservicePFR.Domain.DTOs;
using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroservicePFR.Services
{
    public class RecommendedService : IRecommendedService
    {
        private List<RecommendedDTO> recommendedArticles;
        private IRecommendedRepository repository;
        public RecommendedService(IRecommendedRepository repository) {
            this.repository = repository;   
        }
        public List<RecommendedDTO> GetAllRecommendedArticlesBy(string category)
        {
            Random random = new Random();
            recommendedArticles = new List<RecommendedDTO>();
            for (int i=0; i<30; i++) {


                recommendedArticles.Add(new RecommendedDTO
                {
                    articleDescription = "This is the article " + i + " description.",
                    articleId = Guid.NewGuid().ToString(),
                    articleImage = "some url image",
                    articleName = "Article " + i,
                    articlePrice = "5600",
                    category = "Category "+random.Next(1, 6)

                });


            }
            return recommendedArticles.Where(x=>x.category==category).ToList();
        }

        public string GetHigherInterestCategory(string userId)
        {
            List<InterestCategory> categories = repository.GetInterestCategoriesBy(userId);

            var orderedCategories = categories.Where(x => x.userId == userId).OrderByDescending(y => y.amountOfViews).ToList();
            return orderedCategories.First().interestCategoryId;
        }
            
    }
}
