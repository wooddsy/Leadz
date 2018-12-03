using System;
using Newtonsoft.Json;

namespace Leadz.WebFE.Models
{
	[JsonObject]
	public class Lead : Entity
	{
		[JsonProperty("surname")]
		public string Surname { get; set; }

		[JsonProperty("houseNumber")]
		public long HouseNumber { get; set; }

		[JsonProperty("street")]
		public string Street { get; set; }

		[JsonProperty("town")]
		public string Town { get; set; }

		[JsonProperty("postCode")]
		public string PostCode { get; set; }

		[JsonProperty("noOfDoors")]
		public long NoOfDoors { get; set; }

		[JsonProperty("noOfWindows")]
		public long NoOfWindows { get; set; }

		[JsonProperty("appointmentDateTime")]
		public System.DateTimeOffset AppointmentDateTime { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("dateTaken")]
		public System.DateTimeOffset DateTaken { get; set; }

		[JsonProperty("canvasserId")]
		public string CanvasserId { get; set; }
		}
}