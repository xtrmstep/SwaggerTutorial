using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    /// Data transfer object to Read or Update books
    /// </summary>
    public class BookReadModel
    {
        /// <summary>
        /// Book identifier
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Book title 
        /// </summary>
        [Required]
        public string Title { get; set; }
    }
}