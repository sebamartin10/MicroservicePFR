using System.ComponentModel.DataAnnotations;

namespace MicroservicePFR.Domain.Models
{
    public class InterestCategory
    {

        [Key]
        public string interestCategoryId { get; set; }
        public string userId { get; set; }
        public int amountOfViews { get; set; }
    }
}
