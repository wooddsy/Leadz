using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leadz.Api.Data;
using Leadz.Api.Models;

namespace Leadz.WebFE.Pages.Canvasser
{
	public class EditModel : PageModel
	{
		private readonly IApiClient<Models.Canvasser> _context;

		public EditModel(IApiClient<Models.Canvasser> context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.Canvasser Canvasser { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			

			Canvasser = await _context.GetLeadAsync("Canvassers", id);

			if (Canvasser == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await _context.PutLeadAsync("Canvassers",Canvasser.Id, Canvasser);


			return RedirectToPage("./Index");
		}
	}
}
