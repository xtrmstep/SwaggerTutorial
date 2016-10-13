namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    ///     Data transfer object to create or update stores
    /// </summary>
    public class StoreUpdateModel
    {
        /// <summary>
        ///     Store name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Store address
        /// </summary>
        public string Address { get; set; }
    }
}