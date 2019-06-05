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

        private IRepository<Person> _personRepository;

        private IRepository<PersonProfile> _personProfileRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The database object</param>
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IRepository<Person> PersonRepository =>
            _personRepository ?? (_personRepository = new Repository<Person>(_context));

        public IRepository<PersonProfile> PersonProfileRepository =>
            _personProfileRepository ?? (_personProfileRepository = new Repository<PersonProfile>(_context));

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
