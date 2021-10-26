using System.ComponentModel.DataAnnotations;

namespace MicroservicePFR.Domain.Models
{
   
    public class Favourite
    {
        public string userID { get; set; }
        [Key]
        public string articleID { get; set; }

        
    }
}
