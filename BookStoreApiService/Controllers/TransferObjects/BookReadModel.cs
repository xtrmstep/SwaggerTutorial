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
        public int Id { get; set; }
        /// <summary>
        /// Book title 
        /// </summary>
        public string Title { get; set; }
    }
}