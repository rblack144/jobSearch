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
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _unitOfWork.PersonRepository.GetAll();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
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

        // PUT: api/People/5
        [HttpPut("{id}")]
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

            //_unitOfWork.Entry(person).State = EntityState.Modified;

            //try
            //{
            //    await _unitOfWork.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public IActionResult PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PersonRepository.Insert(person);
            //await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
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
            //await _unitOfWork.SaveChangesAsync();

            return Ok(person);
        }

        //private bool PersonExists(int id)
        //{
        //    return _unitOfWork.Persons.Any(e => e.Id == id);
        //}
    }
}