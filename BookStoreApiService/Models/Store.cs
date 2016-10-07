using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookStoreApiService.Models
{
    public class Store : Entity
    {
        /// <summary>
        /// Store name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Store address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// All books in the store
        /// </summary>
        public IList<Book> Books { get; set; } = new List<Book>();

        /// <summary>
        /// All authors whose books are in the store
        /// </summary>
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}