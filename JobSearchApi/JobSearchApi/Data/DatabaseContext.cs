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

        /// <summary>
        /// The type of jobs
        /// </summary>
        public virtual DbSet<JobType> JobTypes { get; set; }

        /// <summary>
        /// The job searches belonging to a person
        /// </summary>
        public virtual DbSet<PersonJobSearch> PersonJobSearches { get; set; }

        /// <summary>
        /// Specify how models should be created
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the jobs table
            modelBuilder.Entity<JobType>().HasData(
                new JobType { Id = 1, Description = "Full Time" },
                new JobType { Id = 2, Description = "Part Time"},
                new JobType { Id = 3, Description = "Contract" }
                );
        }

    }
}
