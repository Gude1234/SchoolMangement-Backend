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
    public class StudentAttendencesController : ControllerBase
    {
        private readonly IStudentAttendenceRepository _studentAttendenceRepository;

        public StudentAttendencesController(IStudentAttendenceRepository studentAttendenceRepository)
        {
            this._studentAttendenceRepository = studentAttendenceRepository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendence>>> GetStudentAttendences()
        {
            return await _studentAttendenceRepository.GetAllAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendence>> GetStudentAttendence(int id)
        {
            var attendence = await _studentAttendenceRepository.GetAsync(id);

            if (attendence == null)
            {
                return NotFound();
            }

            return attendence;
        }

        [HttpGet("staff/{id}")]
        public async Task<ActionResult<IEnumerable<StudentAttendence>>> GetStudentAttendenceByStaff(int id)
        {
            var attendence = await _studentAttendenceRepository.GetAttendencebystaff(id);

            if (attendence == null)
            {
                return NotFound();
            }

            return attendence;
        }

        [HttpGet("student/{studentName}/subject/{subjectName}")]
        public async Task<ActionResult<IEnumerable<StudentAttendence>>> GetStudentAttendenceByStudentAndSubject(string studentName , string subjectName)
        {
            var attendences = await _studentAttendenceRepository.GetAttendecnebyStudentAndSubject(studentName,subjectName);

            if (attendences == null)
            {
                return NotFound();
            }

            return attendences;
        }

        [HttpGet("{date}/{staffid}")]
        public async Task<ActionResult<IEnumerable<StudentAttendence>>> GetStudentAttendenceByDateAndStaff(string date, int staffid)
        {
            var attendences = await _studentAttendenceRepository.GetAttendencebystaffAndDate(date, staffid);

            if (attendences == null)
            {
                return NotFound();
            }

            return attendences;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendence(int id, StudentAttendence studentAttendence)
        {
            if (id != studentAttendence.Id)
            {
                return BadRequest();
            }


            try
            {
                await _studentAttendenceRepository.UpdateAsync(studentAttendence);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentAttendenceExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAttendence>> PostStudentAttendence(StudentAttendence studentAttendence)
        {
            await _studentAttendenceRepository.AddAsync(studentAttendence);

            return CreatedAtAction("GetStudentAttendence", new { id = studentAttendence.Id }, studentAttendence);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAttendence(int id)
        {
            var attendence = await GetStudentAttendence(id);
            if (attendence == null)
            {
                return NotFound();
            }

            await _studentAttendenceRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> StudentAttendenceExists(int id)
        {
            return await _studentAttendenceRepository.Exsits(id);
        }
    }
}
