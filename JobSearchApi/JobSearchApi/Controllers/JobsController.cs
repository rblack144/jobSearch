using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSearchApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApi.Controllers
{
    /// <summary>
    /// The jobs endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public JobsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        /// <summary>
        /// Gets and returns a list of all the job searches
        /// </summary>
        /// <returns>The list of job searches</returns>
        [HttpGet]
        public IEnumerable<PersonJobSearch> Get() => _unitOfWork.PersonJobSearchRepository.GetAll();

        /// <summary>
        /// Get's the job search by id
        /// </summary>
        /// <param name="id">The system id of the job</param>
        /// <returns>The job search entry</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonJobSearch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobSearch = _unitOfWork.PersonJobSearchRepository.GetById(id);
            if (jobSearch == null)
            {
                return NotFound();
            }

            return Ok(jobSearch);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
