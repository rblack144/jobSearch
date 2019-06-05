using JobSearchApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApi
{
    /// <summary>
    /// Repository for a given entity
    /// </summary>
    /// <typeparam name="T">The type of entity</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The database context
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// The database table
        /// </summary>
        private DbSet<T> _table;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The database context</param>
        public Repository(DatabaseContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        /// <summary>
        /// Get all the data
        /// </summary>
        /// <returns>The list of objects</returns>
        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        /// <summary>
        /// Get the item by the given id
        /// </summary>
        /// <param name="id">The id of the item to retrieve</param>
        /// <returns>The item, if it exists</returns>
        public T GetById(object id)
        {
            return _table.Find(id);
        }

        /// <summary>
        /// Insert the given entity
        /// </summary>
        /// <param name="entity">The entity to be inserted</param>
        public void Insert(T entity)
        {
            _table.Add(entity);
        }

        /// <summary>
        /// Update the given entity
        /// </summary>
        /// <param name="entity">The entity to be updated</param>
        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete the given entity with the specified id
        /// </summary>
        /// <param name="id">The id of the entity to be deleted</param>
        public void Delete(object id)
        {
            T existingEntity = _table.Find(id);
            _table.Remove(existingEntity);
        }

        /// <summary>
        /// Save the data
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
