using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace Leadz.WebFE.Pages.Canvasser
{
		public class DeleteModel : PageModel
		{
				private readonly IApiClient<Models.Canvasser> _context;

				public DeleteModel(IApiClient<Models.Canvasser> context)
				{
						_context = context;
				}

				[BindProperty]
				public Models.Canvasser Canvasser { get; set; }

				public async Task<IActionResult> OnGetAsync(int id )
				{


					Canvasser = await _context.GetLeadAsync("Canvassers", id);

						if (Canvasser == null)
						{
								return NotFound();
						}
						return Page();
				}

				public async Task<IActionResult> OnPostAsync(int id)
				{
						

						await _context.RemoveLeadAsync("Canvassers", id);
					 

						return RedirectToPage("./Index");
				}
		}
}
