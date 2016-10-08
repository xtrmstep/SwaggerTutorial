using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Models;

namespace BookStoreApiService.Data
{
    public static class Database<T> where T : Entity, new()
    {
        private static readonly Dictionary<int, T> _data = new Dictionary<int, T>();

        public static void Create(T entity)
        {
            var newId = _data.Keys.Count == 0 ? 0 : _data.Keys.Max() + 1;
            entity.Id = newId;
            _data.Add(newId, entity);
        }
        public static T Read(int id)
        {
            T entity;
            return _data.TryGetValue(id, out entity) ? entity : null;
        }

        public static IList<T> Read()
        {
            return _data.Values.ToList();
        }

        /// <summary>
        /// Updates the existing data
        /// </summary>
        /// <param name="entity">Existing data which shall be updated using its ID</param>
        /// <exception cref="DataNotFoundException">Raised when data cannot be found by the identifier</exception>
        public static void Update(T entity)
        {
            if (_data.ContainsKey(entity.Id))
                _data[entity.Id] = entity;
            else
                throw new DataNotFoundException();
        }

        public static void Delete(int id)
        {
            if (!_data.ContainsKey(id))
                throw new DataNotFoundException();

            _data.Remove(id);
        }

        public static void Clear()
        {
            _data.Clear();
        }
    }
}