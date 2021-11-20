using MicroservicePFR.Domain.Models;
using MicroservicePFR.Domain.Repository;
using MicroservicePFR.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicePFR.Application
{
    public class AddInterestCategory
    {
       
        IInterestCategoryService service; 
        IAuthService authService;
        List<string> categories;
        public AddInterestCategory(IInterestCategoryService service, IAuthService authService) {
         
            this.service = service;
            this.authService = authService;
            categories = new List<string> { "Category A", "Category B", "Category C","Category D","Category E","Category F","Category G" };
        }
        public async Task AddCategory(InterestCategory interestCategory)
        {
            var user = authService.GetCurrentUser();
            interestCategory.userId = user.id;
            //string categoryId = GetRandomCategory();
            var category = await service.GetCategoryById(interestCategory.interestCategoryId,interestCategory.userId);
            if (category!=null)
            {
                category.amountOfViews++;
                await service.Update(category);
            }
            else {
                interestCategory.amountOfViews = 1;
                interestCategory.interestCategoryId = interestCategory.interestCategoryId;
                await service.Create(interestCategory);
            }
            
        }
        private string GetRandomCategory() {
            Random rd = new Random();
            int rand_num = rd.Next(0, categories.Count);
            return categories[rand_num];
        }
    }
    
}
