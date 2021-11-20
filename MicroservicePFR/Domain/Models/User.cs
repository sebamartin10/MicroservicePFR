using System.Collections.Generic;

namespace MicroservicePFR.Domain.Models
{
    public class User
    {
        public string id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public List<string> permissions { get; set; }
    }
}
