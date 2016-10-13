using System;

namespace BookStoreApiService.Controllers.TransferObjects
{
    public class BookPublisherInfo
    {
        /// <summary>
        ///     Name of the publisher
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Date of publishing
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        ///     Number of published books
        /// </summary>
        public int Count { get; set; }
    }
}