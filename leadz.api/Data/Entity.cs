using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leadz.Api.Data
{
	public abstract class Entity<T> : IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
		
		private DateTime? createdDate;
		[JsonProperty("createdDate")]
		[DataType(DataType.DateTime)]
		public DateTime CreatedDate
		{
			get { return createdDate ?? DateTime.UtcNow; }
			set { createdDate = value; }
		}
		[JsonProperty("modifiedDate")]
		[DataType(DataType.DateTime)] public DateTime? ModifiedDate { get; set; }

		[JsonProperty("createdBy")]
		public string CreatedBy { get; set; }
		[JsonProperty("modifiedBy")]
		public string ModifiedBy { get; set; }
		[JsonProperty("version")]
		[Timestamp] public byte[] Version { get; set; }

		}
}