using System.Collections.Generic;

namespace BookStoreApiService.Models
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Book> Books { get; set; }
        public IList<Author> Authors { get; set; }
    }
}