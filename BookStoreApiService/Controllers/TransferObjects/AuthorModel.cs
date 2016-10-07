using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    /// Data transfer object to Read or Update authors
    /// </summary>
    public class AuthorModel
    {
        /// <summary>
        /// Author identifier
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Author full name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}