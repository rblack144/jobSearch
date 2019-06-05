using JobSearchApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApi
{
    #region Repository Interface
    /// <summary>
    /// Repository for a given entity
    /// </summary>
    /// <typeparam name="T">The type of entity</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all the data
        /// </summary>
        /// <returns>The list of objects</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get the item by the given id
        /// </summary>
        /// <param name="id">The id of the item to retrieve</param>
        /// <returns>The item, if it exists</returns>
        T GetById(object id);

        /// <summary>
        /// Insert the given entity
        /// </summary>
        /// <param name="entity">The entity to be inserted</param>
        void Insert(T entity);

        /// <summary>
        /// Update the given entity
        /// </summary>
        /// <param name="entity">The entity to be updated</param>
        void Update(T entity);

        /// <summary>
        /// Delete the given entity with the specified id
        /// </summary>
        /// <param name="id">The id of the entity to be deleted</param>
        void Delete(object id);

        /// <summary>
        /// Save the data
        /// </summary>
        void Save();
    }
    #endregion

    #region Unit Of Work Interface
    /// <summary>
    /// The unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> PersonRepository { get; }

        IRepository<PersonProfile> PersonProfileRepository { get; }

        void Save();
    }
    #endregion
}
