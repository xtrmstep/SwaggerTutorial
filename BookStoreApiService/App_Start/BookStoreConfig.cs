using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using BookStoreApiService.Controllers.TransferObjects;
using BookStoreApiService.Data;
using BookStoreApiService.Models;

namespace BookStoreApiService.App_Start
{
    public static class BookStoreConfig
    {
        public static void Register()
        {
            InitMapper();
            DatabaseSeed.Init();
        }

        internal static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorModel>();
                cfg.CreateMap<Author, AuthorCreateModel>();
                cfg.CreateMap<AuthorModel, Author>();
                cfg.CreateMap<AuthorCreateModel, Author>();

                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<Book, BookCreateModel>();
                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<BookCreateModel, Book>();

                cfg.CreateMap<Store, StoreReadModel>();
                cfg.CreateMap<Store, StoreWriteModel>();
                cfg.CreateMap<StoreReadModel, Store>();
                cfg.CreateMap<StoreWriteModel, Store>();
            });
        }
    }
}