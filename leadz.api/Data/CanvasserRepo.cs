using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leadz.Api.Models;

namespace Leadz.Api.Data
{
	public class CanvasserRepo : EFRepo<Canvasser>, ICanvasserRepo
	{
		public CanvasserRepo(Context dbContext)
			: base(dbContext)
		{ }
	}
}