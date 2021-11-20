using System.ComponentModel.DataAnnotations;

namespace MicroservicePFR.Domain.Models
{
    public class UserProfile
    {
        [Key]
        public string userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string urlImage { get; set; }
    }
}
