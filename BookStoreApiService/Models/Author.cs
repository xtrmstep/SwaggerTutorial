using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BookStoreApiService.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Author : Entity
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        public IList<Book> Books { get; set; } = new List<Book>();
    }
}