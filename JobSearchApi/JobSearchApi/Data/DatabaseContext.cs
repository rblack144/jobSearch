using JobSearchApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApi.Data
{
    /// <summary>
    /// The database context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">Options for the database context</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        /// <summary>
        /// A person
        /// </summary>
        public virtual DbSet<Person> Persons { get; set; }

        /// <summary>
        /// The profile belonging to a person
        /// </summary>
        public virtual DbSet<PersonProfile> PersonProfiles { get; set; }

    }
}
