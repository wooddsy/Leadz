using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Leadz.WebFE.Models;


namespace Leadz.WebFE.Pages.Canvasser
{
	public class IndexModel : PageModel
	{
		private readonly IApiClient<Models.Canvasser> _context;

		public IndexModel(IApiClient<Models.Canvasser> context)
		{
			_context = context;
		}

		public IList<Models.Canvasser> Canvasser { get; set; }

		public async Task OnGetAsync()
		{
			Canvasser = await _context.GetLeadsAsync("Canvassers");
		}
	}
}
