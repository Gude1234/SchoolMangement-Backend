using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;
using SchoolMangement.Models;

namespace SchoolMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredSubjectsController : ControllerBase
    {
        private readonly IRegisteredSubjectsRepository _registeredSubjectsRepository;

        public RegisteredSubjectsController(IRegisteredSubjectsRepository registeredSubjectsRepository)
        {
            this._registeredSubjectsRepository = registeredSubjectsRepository;
        }

        // GET: api/RegisteredSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredSubjects>>> GetRegisteredSubjects()
        {
            return await _registeredSubjectsRepository.GetAllAsync();
        }

        // GET: api/RegisteredSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredSubjects>> GetRegisteredSubject(int id)
        {
            var registeredSubjects = await _registeredSubjectsRepository.GetAsync(id);

            if (registeredSubjects == null)
            {
                return NotFound();
            }

            return registeredSubjects;
        }

        [HttpGet("staff/{id}")]
        public async Task<ActionResult<IEnumerable<RegisteredSubjects>>> GetRegisteredSubjectbyStaff(int id)
        {
            var registeredSubjects = await _registeredSubjectsRepository.GetByStaff(id);

            if (registeredSubjects == null)
            {
                return NotFound();
            }

            return registeredSubjects;
        }

        [HttpGet("student/{name}")]
        public async Task<ActionResult<IEnumerable<RegisteredSubjects>>> GetRegisteredSubjectbyStudent(string name)
        {
            var registeredSubjects = await _registeredSubjectsRepository.GetByStudent(name);

            if (registeredSubjects == null)
            {
                return NotFound();
            }

            return registeredSubjects;
        }

        // PUT: api/RegisteredSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteredSubjects(int id, RegisteredSubjects registeredSubjects)
        {
            if (id != registeredSubjects.Id)
            {
                return BadRequest();
            }

            try
            {
                await _registeredSubjectsRepository.UpdateAsync(registeredSubjects);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RegisteredSubjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RegisteredSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisteredSubjects>> PostRegisteredSubjects(RegisteredSubjects registeredSubjects)
        {
            await _registeredSubjectsRepository.AddAsync(registeredSubjects);

            return CreatedAtAction("GetRegisteredSubjects", new { id = registeredSubjects.Id }, registeredSubjects);
        }

        // DELETE: api/RegisteredSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredSubjects(int id)
        {
            var registeredSubjects = await GetRegisteredSubject(id);
            if (registeredSubjects == null)
            {
                return NotFound();
            }

            await _registeredSubjectsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> RegisteredSubjectsExists(int id)
        {
            return await _registeredSubjectsRepository.Exsits(id);
        }
    }
}
