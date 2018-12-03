using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leadz.Api.Data;
using Leadz.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leadz.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Leads")]
	public class LeadsController : Controller
	{
		private readonly ILeadRepo _context;

		public LeadsController(ILeadRepo context)
		{
			_context = context;
		}

		// GET: api/Leads
		[HttpGet]
		public Task<IEnumerable<Lead>> GetLead()
		{
			return _context.GetAll();
		}

		// GET: api/Leads/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetLead([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var lead = await _context.GetById(id);

			if (lead == null)
			{
				return NotFound();
			}

			return Ok(lead);
		}

		// PUT: api/Leads/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLead([FromRoute] int id, [FromBody] Lead lead)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Convert.ToInt32(lead.Id))
			{
				return BadRequest();
			}

			await _context.Update(id, lead);


			return Ok();
		}

		// POST: api/Leads
		[HttpPost]
		public async Task<IActionResult> PostLead([FromBody] Lead lead)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _context.Create(lead);


			return CreatedAtAction("GetLead", new {id = lead.Id}, lead);
		}

		// DELETE: api/Leads/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLead([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}


			await _context.Delete(id);

			return NoContent();
		}
	}
}