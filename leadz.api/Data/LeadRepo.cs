using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leadz.Api.Models;

namespace Leadz.Api.Data
{
	public class LeadRepo : EFRepo<Lead>, ILeadRepo
	{
		public LeadRepo(Context dbContext)
			: base(dbContext)
		{ }
	}
}