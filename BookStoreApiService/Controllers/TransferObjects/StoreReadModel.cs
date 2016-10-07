using System.ComponentModel.DataAnnotations;

namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    /// Data transfer object to Read stores
    /// </summary>
    public class StoreReadModel
    {
        /// <summary>
        /// Store identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Store name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Store address
        /// </summary>
        public string Address { get; set; }
    }
}