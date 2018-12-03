using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Leadz.WebFE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Leadz.WebFE.Pages.Leads
{
		public class LeadsListModel : PageModel
		{
			private Lead _lead;
			public LeadsListModel(Lead lead)
			{
				_lead = lead;
			}

			  //public LeadList Leads = new LeadList();
				public List<Lead> LeadList = new List<Lead>();
				public async Task<IActionResult> OnGet()
			{
				var client = new HttpClient();
					
						client.BaseAddress = new Uri("http://localhost:55795/api/Leads");
						client.DefaultRequestHeaders.Clear();
						client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
						var response = await client.GetAsync("", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
						if (response.IsSuccessStatusCode)
						{
							
							JsonSerializerSettings           settings         = new JsonSerializerSettings();
							
							String                           responseString   = await response.Content.ReadAsStringAsync();
							LeadList = JsonConvert.DeserializeObject<List<Lead>>(responseString, settings);
							

						}

					

						return Page();
				}
		}
}