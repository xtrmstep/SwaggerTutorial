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
                cfg.CreateMap<Author, AuthorReadModel>();
                cfg.CreateMap<Author, AuthorCreateModel>();
                cfg.CreateMap<Author, AuthorUpdateModel>();
                cfg.CreateMap<AuthorCreateModel, Author>();
                cfg.CreateMap<AuthorUpdateModel, Author>()
                    // copy value from Src member to Dest if it is not NULL
                    .ForMember(dest => dest.Name, opt => opt.Ignore()).AfterMap((src, dest) => { if (src.Name != null) dest.Name = src.Name; });

                cfg.CreateMap<Book, BookReadModel>();
                cfg.CreateMap<Book, BookCreateModel>();
                cfg.CreateMap<Book, BookUpdateModel>();
                cfg.CreateMap<BookCreateModel, Book>();
                cfg.CreateMap<BookUpdateModel, Book>()
                    .ForMember(dest => dest.Title, opt => opt.Ignore()).AfterMap((src, dest) => { if (src.Title != null) dest.Title = src.Title; });

                cfg.CreateMap<Store, StoreReadModel>();
                cfg.CreateMap<Store, StoreCreateModel>();
                cfg.CreateMap<Store, StoreUpdateModel>();
                cfg.CreateMap<StoreCreateModel, Store>();
                cfg.CreateMap<StoreUpdateModel, Store>()
                    .ForMember(dest => dest.Name, opt => opt.Ignore()).AfterMap((src, dest) => { if (src.Name != null) dest.Name = src.Name; })
                    .ForMember(dest => dest.Address, opt => opt.Ignore()).AfterMap((src, dest) => { if (src.Address != null) dest.Address = src.Address; });
            });
        }
    }
}