using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApi
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// The database context
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The database object</param>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save the data
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
