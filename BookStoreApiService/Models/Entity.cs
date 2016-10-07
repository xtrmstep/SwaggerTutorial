using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class Entity
    {
        /// <summary>
        /// Identifier of the object
        /// </summary>
        [Required]
        [DataMember]
        public int Id { get; set; }
    }
}