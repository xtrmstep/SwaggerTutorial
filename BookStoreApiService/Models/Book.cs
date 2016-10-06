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
        /// <summary>
        /// Book title 
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Authors of the book
        /// </summary>
        public IList<Author> Authors { get; set; } = new List<Author>();
    }
}