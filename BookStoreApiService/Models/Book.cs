using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApiService.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}