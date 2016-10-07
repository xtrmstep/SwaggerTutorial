using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    public class AuthorCreateModel
    {
        /// <summary>
        /// Author full name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}