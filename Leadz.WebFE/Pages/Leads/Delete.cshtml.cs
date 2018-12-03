using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leadz.WebFE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Leadz.WebFE.Pages.Leads
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient<Lead> _context;

        public DeleteModel(IApiClient<Lead> context)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
           

            Lead = await _context.GetLeadAsync("Leads", id);

            if (Lead != null)
            {
                await _context.RemoveLeadAsync("Leads", id);
                
            }

            return RedirectToPage("./Index");
        }
    }
}
