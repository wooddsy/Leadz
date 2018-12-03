using System;

namespace Leadz.Api.Data
{
	public interface IEntity
	{
		int       Id           { get; set; }
		DateTime  CreatedDate  { get; set; }
		DateTime? ModifiedDate { get; set; }
		string    CreatedBy    { get; set; }
		string    ModifiedBy   { get; set; }
		byte[]    Version      { get; set; }
	}
}