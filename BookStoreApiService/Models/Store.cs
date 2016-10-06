using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookStoreApiService.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Store : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        public IList<Book> Books { get; set; } = new List<Book>();

        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}