using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Leadz.WebFE.Models;

namespace Leadz.WebFE.Pages.Leads
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient<Lead> _context;

        public CreateModel(IApiClient<Lead> context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lead Lead { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.AddLeadAsync("Leads",Lead);
            

            return RedirectToPage("./Index");
        }
    }
}