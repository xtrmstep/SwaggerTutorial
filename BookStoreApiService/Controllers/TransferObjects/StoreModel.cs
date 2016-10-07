using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    /// Data transfer object to Read or Update stores
    /// </summary>
    public class StoreModel
    {
        /// <summary>
        /// Store identifier
        /// </summary>
        [Required]
        public int Id { get; set; }
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