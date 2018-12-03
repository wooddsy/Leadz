using System.Collections.Generic;
using Leadz.Api.Data;
using Newtonsoft.Json;

namespace Leadz.Api.Models
{
	public class Canvasser : Entity<int>
	{
	

		[JsonProperty("teamId")]
		public long TeamId { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("phoneNo")]
		public long PhoneNo { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }


		}
}