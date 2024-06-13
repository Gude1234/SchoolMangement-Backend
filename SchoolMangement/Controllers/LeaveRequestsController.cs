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
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveRequestsController(ILeaveRepository leaveRepository)
        {
            this._leaveRepository = leaveRepository;
        }

        // GET: api/LeaveRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequests()
        {
            return await _leaveRepository.GetAllAsync();
        }

        // GET: api/LeaveRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetLeaveRequest(int id)
        {
            var leaveRequest = await _leaveRepository.GetAsync(id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            return leaveRequest;
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequestByName(string name)
        {
            var leaveRequest = await _leaveRepository.GetByName(name);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            return leaveRequest;
        }

        // PUT: api/LeaveRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveRequest(int id, LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return BadRequest();
            }

            try
            {
                await _leaveRepository.UpdateAsync(leaveRequest);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LeaveRequestExists(id))
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

        // POST: api/LeaveRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> PostLeaveRequest(LeaveRequest leaveRequest)
        {
            await _leaveRepository.AddAsync(leaveRequest);

            return CreatedAtAction("GetLeaveRequest", new { id = leaveRequest.Id }, leaveRequest);
        }

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leaveRequest = await GetLeaveRequest(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            await _leaveRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LeaveRequestExists(int id)
        {
            return await _leaveRepository.Exsits(id);
        }
    }
}
