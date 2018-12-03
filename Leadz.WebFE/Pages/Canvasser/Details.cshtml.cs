using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Leadz.Api.Data;
using Leadz.Api.Models;

namespace Leadz.WebFE.Pages.Canvasser
{
    public class DetailsModel : PageModel
    {
        private readonly IApiClient<Models.Canvasser> _context;

        public DetailsModel(IApiClient<Models.Canvasser> context)
        {
            _context = context;
        }

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
    }
}
