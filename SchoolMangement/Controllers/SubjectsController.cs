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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            this._subjectRepository = subjectRepository;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetSubjects()
        {
            return await _subjectRepository.GetAllAsync();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subjects>> GetSubject(int id)
        {
            var subjects = await _subjectRepository.GetAsync(id);

            if (subjects == null)
            {
                return NotFound();
            }

            return subjects;
        }

        [HttpGet("course/{id}")]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetSubjectsbyCourse(int id)
        {
            var subjects = await _subjectRepository.GetSubjectsByCourse(id);

            if (subjects == null)
            {
                return NotFound();
            }

            return subjects;
        }


        [HttpGet("staff/{id}")]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetSubjectsbyStaff(int id)
        {
            var subjects = await _subjectRepository.GetSubjectsByStaff(id);

            if (subjects == null)
            {
                return NotFound();
            }

            return subjects;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjects(int id, Subjects subjects)
        {
            if (id != subjects.Id)
            {
                return BadRequest();
            }

            try
            {
                await _subjectRepository.UpdateAsync(subjects);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SubjectsExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subjects>> PostSubjects(Subjects subjects)
        {
            await _subjectRepository.AddAsync(subjects);

            return CreatedAtAction("GetSubjects", new { id = subjects.Id }, subjects);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjects(int id)
        {
            var subjects = await GetSubject(id);
            if (subjects == null)
            {
                return NotFound();
            }

            await _subjectRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SubjectsExists(int id)
        {
            return await _subjectRepository.Exsits(id);
        }
    }
}
