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

namespace Leadz.WebFE.Pages.Leads
{
		public class EditModel : PageModel
		{
				private readonly IApiClient<Lead> _context;

				public EditModel(IApiClient<Lead> context)
				{
						_context = context;
				}

				[BindProperty]
				public Lead Lead { get; set; }

				public async Task<IActionResult> OnGetAsync(int id)
				{
					 

						Lead = await _context.GetLeadAsync("Leads", id);

						if (Lead == null)
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

					await _context.PutLeadAsync("leads", Lead.Id, Lead);
				 
						
					return RedirectToPage("./Index");
				}

			 
		}
}
