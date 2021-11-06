namespace MicroservicePFR.Domain.DTOs
{
    public class ArticleDTO
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string updated { get; set; }
        public string created { get; set; }
        public string enabled { get; set; }
    }
}
