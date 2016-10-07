using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    public class StoreCreateModel
    {
        /// <summary>
        /// Store name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Store address
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}