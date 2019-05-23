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
        public int ID { get; set; }

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
        public int ID { get; set; }

        /// <summary>
        /// The system id of the person to whom this profile belong
        /// </summary>
        public int PersonID { get; set; }

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
}
