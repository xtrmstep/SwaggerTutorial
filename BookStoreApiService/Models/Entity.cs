using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BookStoreApiService.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class Entity
    {
        /// <summary>
        /// Identifier of the object
        /// </summary>
        [DataMember]
        public int Id { get; set; }
    }
}