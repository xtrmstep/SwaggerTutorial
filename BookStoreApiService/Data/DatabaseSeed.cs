using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreApiService.Models;

namespace BookStoreApiService.Data
{
    public static class DatabaseSeed
    {
        private static bool _initialized = false;
        public static void Init()
        {
            if (_initialized) return;
            _initialized = true;

            Database<Author>.Clear();
            Database<Author>.Clear();
            Database<Author>.Clear();

            var author1 = new Author {Name = "Author 1" };
            var author2 = new Author { Name = "Author 2" };
            var author3 = new Author { Name = "Author 3" };

            Database<Author>.Create(author1);
            Database<Author>.Create(author2);
            Database<Author>.Create(author3);

            var book1 = new Book {Title = "Title 1"};
            var book2 = new Book {Title = "Title 2"};
            var book3 = new Book {Title = "Title 3"};

            Database<Book>.Create(book1);
            Database<Book>.Create(book2);
            Database<Book>.Create(book3);

            var store1 = new Store { Name = "Store 1" };
            var store2 = new Store { Name = "Store 2" };
            var store3 = new Store { Name = "Store 3" };

            Database<Store>.Create(store1);
            Database<Store>.Create(store2);
            Database<Store>.Create(store3);

            // ============================

            // Book 1 is written by two authors: Author 1 and Author 2. It may be found in Store 1
            book1.Authors.Add(author1);
            book1.Authors.Add(author2);
            author1.Books.Add(book1);
            author2.Books.Add(book1);
            store1.Books.Add(book1);
            store1.Authors.Add(author1);
            store1.Authors.Add(author2);

            // Book 2 is written by Author 1 and may be found in two stores: Store 1 and Store 3
            book2.Authors.Add(author1);
            author1.Books.Add(book2);
            // author is already added to the store, so that only book should be added
            store1.Books.Add(book2);

            // Book 3 is written by Author 3 and may be found in all stores: Store 1, Store 2 and Store 3
            book3.Authors.Add(author3);
            author3.Books.Add(book3);
            store1.Books.Add(book3);
            store2.Books.Add(book3);
            store3.Books.Add(book3);
        }
    }
}