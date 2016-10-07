using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    public class BookCreateModel
    {
        /// <summary>
        /// Book title 
        /// </summary>
        [Required]
        public string Title { get; set; }
    }
}