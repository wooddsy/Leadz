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
		public class DetailsModel : PageModel
		{
				private readonly IApiClient<Lead> _apiClient;

				public DetailsModel(IApiClient<Lead> apiClient)
				{
						_apiClient = apiClient;
				}

				public Lead Lead { get; set; }

				public async Task<IActionResult> OnGetAsync(int id)
				{
						

						Lead = await _apiClient.GetLeadAsync("Leads", id);

						if (Lead == null)
						{
								return NotFound();
						}
						return Page();
				}
		}
}
