using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leadz.Api.Data;
using Leadz.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leadz.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Canvassers")]
	public class CanvassersController : Controller
	{
		private readonly ICanvasserRepo _context;

		public CanvassersController(ICanvasserRepo context)
		{
			_context = context;
		}

		// GET: api/Canvassers
		[HttpGet]
		public async Task<IEnumerable<Canvasser>> GetCanvasser()
		{
			return await _context.GetAll();
		}

		// GET: api/Canvassers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCanvasser([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var canvasser = await _context.GetById(id);

			if (canvasser == null)
			{
				return NotFound();
			}

			return Ok(canvasser);
		}

		// PUT: api/Canvassers/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCanvasser([FromRoute] int id, [FromBody] Canvasser canvasser)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Convert.ToInt32(canvasser.Id))
			{
				return BadRequest();
			}

			await _context.Update(id, canvasser);

			return Ok();
		}

		// POST: api/Canvassers
		[HttpPost]
		public async Task<IActionResult> PostCanvasser([FromBody] Canvasser canvasser)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _context.Create(canvasser);


			return CreatedAtAction("GetCanvasser", new {id = canvasser.Id}, canvasser);
		}

		// DELETE: api/Canvassers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCanvasser([FromRoute] int id)
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