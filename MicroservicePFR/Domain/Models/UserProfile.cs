using System.ComponentModel.DataAnnotations;

namespace MicroservicePFR.Domain.Models
{
    public class UserProfile
    {
        [Key]
        public string userID { get; set; }
        public string name { get; set; }
        public string urlImage { get; set; }
    }
}
