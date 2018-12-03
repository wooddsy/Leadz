using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Leadz.Api.Models;

namespace Leadz.WebFE
{
	public interface IApiClient<T>
	{

		Task<List<T>>   GetLeadsAsync(string route);
		Task<T>         GetLeadAsync(string route, int    id);
		Task               PutLeadAsync(string route, int id, object   leadToUpdate);
		Task               AddLeadAsync(string route, object   leadToAdd);
		Task               RemoveLeadAsync(string route, int id);

	}
		public class ApiClient<T> : IApiClient<T>
		{
			private readonly HttpClient _httpClient;

			public ApiClient(HttpClient httpClient)
			{
				_httpClient = httpClient;
			}

			public async Task<List<T>> GetLeadsAsync(string route)
			{
				var responce = await _httpClient.GetAsync($"/api/{route}/");
				responce.EnsureSuccessStatusCode();
				return await responce.Content.ReadAsJsonAsync<List<T>>();
			}

			public async Task<T> GetLeadAsync(string route, int id)
			{
				var responce = await _httpClient.GetAsync($"/api/{route}/{id}");
				responce.EnsureSuccessStatusCode();
				return await responce.Content.ReadAsJsonAsync<T>();
				}

			public async Task PutLeadAsync(string route, int id, object leadToUpdate)
			{
				var responce = await _httpClient.PutJsonAsync($"/api/{route}/{id}", leadToUpdate);
				}

			public async Task AddLeadAsync(string route, object leadToAdd)
			{
				var responce = await _httpClient.PostJsonAsync($"/api/{route}/", leadToAdd);
			}

			public async Task RemoveLeadAsync(string route, int id)
			{
				var response = await _httpClient.DeleteAsync($"/api/{route}/{id}");

				response.EnsureSuccessStatusCode();
				}
		}
}
