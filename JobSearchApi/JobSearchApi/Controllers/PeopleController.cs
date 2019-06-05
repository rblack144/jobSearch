using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSearchApi.Data;
using JobSearchApi.Entities;

namespace JobSearchApi.Controllers
{
    /// <summary>
    /// Endpoint to manage people
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Defafault constructor
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public PeopleController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        /// <summary>
        /// Get's a list of all the people
        /// </summary>
        /// <returns>The list of all persons</returns>
        [HttpGet]
        public IEnumerable<Person> GetPersons() => _unitOfWork.PersonRepository.GetAll();

        /// <summary>
        /// Get's the person with the specified system id
        /// </summary>
        /// <param name="id">The system id of the person</param>
        /// <returns>The person if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _unitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Update the specified person
        /// </summary>
        /// <param name="id">The system id of the person to update</param>
        /// <param name="person">The objected containing the updated data</param>
        /// <returns>The status code 204 if successful</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PersonRepository.Update(person);
            return NoContent();
        }

        /// <summary>
        /// Creates the specified person
        /// </summary>
        /// <param name="person">The person to be created</param>
        /// <returns>The system id of the person that was created</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PersonRepository.Insert(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        /// <summary>
        /// Delete's the person with the specified id
        /// </summary>
        /// <param name="id">They system id of the person to delete</param>
        /// <returns>The person that was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _unitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _unitOfWork.PersonRepository.Delete(person);
            return Ok(person);
        }
    }
}