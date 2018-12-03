using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leadz.WebFE.Models
{
    public class LeadList
    {
	   public List<Lead> LeadsList { get; set; }

	    public LeadList()
	    {
				LeadsList = new List<Lead>();
	    }
	  }

}
