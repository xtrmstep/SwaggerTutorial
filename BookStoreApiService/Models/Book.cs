using System.Collections.Generic;

namespace BookStoreApiService.Models
{
    public class Book : Entity
    {
        /// <summary>
        ///     Book title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Authors of the book
        /// </summary>
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}