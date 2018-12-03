using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Leadz.Api.Data;
using Leadz.WebFE.Models;


namespace Leadz.WebFE.Pages.Leads
{
		public class IndexModel : PageModel
		{
				private readonly IApiClient<Lead> _apiClient;

				public IndexModel(IApiClient<Lead> client)
				{
					_apiClient = client;
				}

				public IList<Lead> Lead { get;set; }

				public async Task OnGetAsync()
				{
						Lead = await _apiClient.GetLeadsAsync("Leads");
				}
		}
}
