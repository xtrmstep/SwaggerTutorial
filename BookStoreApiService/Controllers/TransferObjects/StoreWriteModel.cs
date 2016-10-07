using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    /// Data transfer object to create or update stores
    /// </summary>
    public class StoreWriteModel
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