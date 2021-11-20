using System.Collections.Generic;

namespace MicroservicePFR.Services
{
    public static class CategoryProvider
    {
        public static List<string> GetCategories() {
            return new List<string> { "Category A", "Category B", "Category C", "Category D", "Category E", "Category F", "Category G", "Category H" };
        }
    }
}
