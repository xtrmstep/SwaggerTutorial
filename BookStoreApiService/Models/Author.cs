using System.Collections.Generic;

namespace BookStoreApiService.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}