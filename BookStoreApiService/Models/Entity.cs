using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Models
{
    public abstract class Entity
    {
        /// <summary>
        /// Identifier of the object
        /// </summary>
        public int Id { get; set; }
    }
}