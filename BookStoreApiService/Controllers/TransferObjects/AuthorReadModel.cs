namespace BookStoreApiService.Controllers.TransferObjects
{
    /// <summary>
    ///     Data transfer object to Read or Update authors
    /// </summary>
    public class AuthorReadModel
    {
        /// <summary>
        ///     Author identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Author full name
        /// </summary>
        public string Name { get; set; }
    }
}