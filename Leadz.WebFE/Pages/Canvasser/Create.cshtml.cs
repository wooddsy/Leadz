using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Leadz.WebFE.Models;

namespace Leadz.WebFE.Pages.Canvasser
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient<Models.Canvasser> _context;

        public CreateModel(IApiClient<Models.Canvasser> context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Canvasser Canvasser { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

	        await _context.AddLeadAsync("Canvassers", Canvasser);

            return RedirectToPage("./Index");
        }
    }
}