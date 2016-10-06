using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace BookStoreApiService.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Book : Entity
    {
        [DataMember]
        public string Title { get; set; }

        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}