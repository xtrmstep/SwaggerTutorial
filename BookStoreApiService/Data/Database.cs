using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreApiService.Models;

namespace BookStoreApiService.Data
{
    public static class Database<T> where T: Entity, new() 
    {
        public static void Create(T entity)
        {
            
        }
        public static T Read(int id)
        {

        }

        public static IList<T> Read()
        {

        }

        public void Update(T entity)
        {
            
        }

        public void Delete(T entity)
        {
            
        }
    }
}