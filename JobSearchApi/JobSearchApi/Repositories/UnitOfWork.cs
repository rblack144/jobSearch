using JobSearchApi.Data;
using JobSearchApi.Entities;
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
        private DatabaseContext _context;

        /// <summary>
        /// The person repository
        /// </summary>
        private IRepository<Person> _personRepository;

        /// <summary>
        /// The person job search repository
        /// </summary>
        private IRepository<PersonJobSearch> _personJobSearchRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The database object</param>
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The person repository
        /// </summary>
        public IRepository<Person> PersonRepository =>
            _personRepository ?? (_personRepository = new Repository<Person>(_context));

        /// <summary>
        /// The person job search repository
        /// </summary>
        public IRepository<PersonJobSearch> PersonJobSearchRepository =>
            _personJobSearchRepository ?? (_personJobSearchRepository = new Repository<PersonJobSearch>(_context));

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
