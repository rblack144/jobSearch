using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchApi.Entities
{
    #region Person
    /// <summary>
    /// A person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The system id of the person
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Firstname { get; set; }

        /// <summary>
        /// The last name of the person
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Lastname { get; set; }

        /// <summary>
        /// The profile of the person
        /// </summary>
        public virtual PersonProfile Profile { get; set; }
    }
    #endregion

    #region Person Profile
    /// <summary>
    /// The profile belonging to a person
    /// </summary>
    public class PersonProfile
    {
        /// <summary>
        /// The system id of the profile
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The system id of the person to whom this profile belong
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The email address of the person
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The password of the person
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    #endregion

    #region Person Job Search
    /// <summary>
    /// The job search entered by a person
    /// </summary>
    public class PersonJobSearch
    {
        /// <summary>
        /// The system id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// The system id of the person
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The title of the job to seach for
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// The system id of the job type
        /// </summary>
        public string JobTypeId { get; set; }

        /// <summary>
        /// The job location
        /// </summary>
        public string JobLocation { get; set; }

        /// <summary>
        /// Filter by jobs posted on or before this date
        /// </summary>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// The job type
        /// </summary>
        public virtual JobType JobType { get; set; }

        /// <summary>
        /// The person
        /// </summary>
        public virtual Person Person { get; set; }
    }
    #endregion

    #region Job Types
    /// <summary>
    /// The types of jobs
    /// </summary>
    public class JobType
    {
        /// <summary>
        /// The system id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        /// <summary>
        /// The job search description
        /// </summary>
        public string Description { get; set; }
    }
    #endregion
}
