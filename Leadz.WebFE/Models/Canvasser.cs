using Newtonsoft.Json;
using System.Collections.Generic;

namespace Leadz.WebFE.Models
{
	[JsonObject]
	public class Canvasser : Entity
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